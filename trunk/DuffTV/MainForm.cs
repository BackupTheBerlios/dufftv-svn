/*
 *  Copyright 2005 GotCode Team <http://gotcode.jelica.se>
 * 
 *  This file is part of DuffTV.
 *
 *  DuffTV is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  DuffTV is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *
 *  You should have received a copy of the GNU General Public License
 *  along with DuffTV; if not, write to the Free Software
 *  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;
using DuffTv.TvGuideBackend;
using System.Collections;
using OwnerDrawnListFWProject;
using DuffTv.Configurator;


namespace DuffTv.Presentation
{
    public partial class MainForm : Form
    {
        //initialize some objects
        private Config prefs;
        Leecher _leech;
        ProgrammeCollection parsedObj;
        CustomListBox custListBox;
        PrefsForm _prefWindow ;


        public MainForm()
        {
            InitializeComponent();
             prefs = new Config();
             if (prefs.CreatedNewConfigFile)
             {
                 MessageBox.Show("New configuration file created. You are advised to look thru Options menu."
                 , "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                
             }

             if (!Directory.Exists(prefs.AppPath + "\\xmltv"))
             {
                 Directory.CreateDirectory(prefs.AppPath + "\\xmltv");
             }

            this.ControlBox = true;
            this.MinimizeBox = false;
             
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnGetListings_Click(object sender, EventArgs e)
        {
            //do nada

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.Blue;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.White;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetListings();
        }

        private void startMeUp()
        {
            //lblStatus.Text = "Starting download...";
            lblStatus.Invoke(new EventHandler(startDownloading));

            Thread.Sleep(700);
        }
        /// <summary>
        /// Starts the downloader as a separate thread
        /// </summary>
        private void startDownloading(object sender, EventArgs e)
        {
            lblStatus.Text = "Starting download...";
            Application.DoEvents();
    //        Thread.Sleep(500);
            string [] _channels =  _leech.DownloadListings();
            lblStatus.Text = String.Format("Creating TV-listing for {0} channels.", _channels.Length + 1);
            Application.DoEvents();
  //          Thread.Sleep(500);
            parseFiles(_channels);
            Application.DoEvents();
//            Thread.Sleep(500);
            parseObjects();
            lblStatus.Text = String.Format("Done.", _channels.Length + 1);
            this.Controls.Add(custListBox);

            Application.DoEvents();

        }

        /// <summary>
        /// Initialize the downloader, and calls startThread to begin download
        /// </summary>
        private void GetListings()
        {

            string[] kanaler = prefs.ChannelListURL;

            try
            {

                _leech = new Leecher(kanaler);
                parsedObj = new ProgrammeCollection();

                // Create the worker thread and start it
                ThreadStart starter = new ThreadStart(this.startMeUp);
                Thread t = new Thread(starter);
                t.Start();

            }
            catch (Exception downloadExcepetion)
            {
                MessageBox.Show(downloadExcepetion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }

        /// <summary>
        /// Parses the XML files with tv listing. Called after the downloader thread has finished.
        /// </summary>
        private void parseFiles(string[] _files)
        {
            foreach (string file in _files)
            {
                string _fileName = prefs.XMLFileStoragePath + file;
                XMLTVParser parser;
                String strXMLFileContents = "";



                if (_fileName.EndsWith(".xml.gz"))
                {
                    //LOG: this
                    // decompress the gziped file to string, and send content to xmltv parser
                    GzipDecompressor gzPack = new GzipDecompressor();
                    strXMLFileContents = gzPack.Decompress(_fileName);

                }
                else
                {
                    if (_fileName.EndsWith(".xml"))
                    {
                        //LOG: this
                        //no need for decompression, read filestream into string at once...
                        StreamReader st = new StreamReader(_fileName);
                        strXMLFileContents = st.ReadToEnd();
                    }
                    else
                        throw new Exception("Unknow filetype. Must be XML or XML.GZ");

                }

                //LOG: this "File downloaded: " + Path.GetFileName(strFileName) + nl + nl;

                parser = new XMLTVParser(strXMLFileContents);
                foreach (Programme oProg in parser.ParsedProgrammes)
                {
                    parsedObj.Add(oProg);
                }
 

            }
       }


        public void parseObjects()
        {
            
            _leech = null;
           

            ProgrammeCollection _tvToday = parsedObj;
            ProgrammeCollection _tvNow = _tvToday.GetCurrentShows();

            // 3 is added to imageheight to get some space between objects
            int itemHeight = 0;
            float fontSize = 0;
            

            if (_tvNow.Count() > 15)
            {
                itemHeight = 22;
                fontSize = 6F;
            }
            else if (_tvNow.Count() > 10)
            {
                itemHeight = 27;
                fontSize = 8F;
            }
            else if (_tvNow.Count() > 8)
            {
                itemHeight = 35;
                fontSize = 10F;
            }
            else
            {
                itemHeight = 35;
                fontSize = 10F;
            }

            custListBox = new CustomListBox(itemHeight);
            custListBox.WrapText = true;
            custListBox.BackColor = Color.White;
            //custListBox.ForeColor = Color.White;

            int imageSize = itemHeight - 3; 
            
            custListBox.Width = 234;
            custListBox.Height = (itemHeight * _tvNow.Count());
            custListBox.Location = new Point(3, 3);



            ImageList _channelImageList = new ImageList();
            _channelImageList.ImageSize = new Size(imageSize, imageSize);
            int i = 0;

            //Populate items
            foreach (Programme prog in _tvNow)
            {
                int _currentPos = _tvToday.IndexOf(prog);
                Programme _nextShow = _tvToday[_currentPos + 1];

                ListItem item1 = new ListItem();
                item1.FontSize = fontSize;
                //item1.TextStyle = FontStyle.Regular;

                item1.Text = String.Format("{0:HH:mm}", prog.StartTime) + " " + prog.Caption;
                item1.Text += "\r\n" + String.Format("{0:HH:mm}", _nextShow.StartTime) + " " + _nextShow.Caption;
                _channelImageList.Images.Add(prog.ChannelImage);
                item1.ImageIndex = i;
                custListBox.Items.Add(item1);
                i++;
            }

            //Assign ImageList
            custListBox.ImageList = _channelImageList;
       
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            _prefWindow = new PrefsForm();
            _prefWindow.Show();

        }

    }
}