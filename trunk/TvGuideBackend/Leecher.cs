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
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DuffTv.Configurator;

namespace DuffTv.TvGuideBackend
{
    public class Leecher
    {
        private Boolean _useProxy = false;
        private string _URI;
        private string _proxyURI;
        private string _proxyUser;
        private string _proxyPass;
        private string _proxyDomain;
        private string _filePath;
        private string[] _channels;
        private string _tvdbURI;

        private Config defaults = new Config();
        private int _ContentLength;

        public Leecher(string[] Channels)
        {
            
            _channels = Channels;
            _tvdbURI = defaults.XMLTVSourceURI;

        }

        public Leecher(string[] Channels, string proxyURI, string proxyUser, string proxyPass, string proxyDomain)
        {
            _channels = Channels;
            _useProxy = true;
            _proxyURI = proxyURI;
            _proxyUser = proxyUser;
            _proxyPass = proxyPass;
            _proxyDomain = proxyDomain;
            _tvdbURI = defaults.XMLTVSourceURI;
            //_filePath = defaults.XMLFileStoragePath + Path.GetFileName(_URI);

        }

        public void Dispose(bool disposing)
        {
            this.Dispose(disposing);
        }

        /// <summary>
        /// Gets the lenght of content we're downloading
        /// </summary>
        public int ContentLength
        {
            get
            {
                return _ContentLength;
            }
        }

        private string FileName(string _URI)
        {
            return Path.GetFileName(_URI);
        }


        public string PathToFile
        {
            get
            {
                return _filePath;
            }

        }

        public void GetChannelImages(Boolean useProxy)
        {
            //TODO: fixa en image downloader!
        }

        public Boolean FileExists(string fname)
        {
            try
            {
                if (File.Exists(defaults.XMLFileStoragePath + fname))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (IOException ioEx)
            {
                throw new Exception("Could not lookup file.");
            }
        }



        public string[] DownloadListings()
        {
            try
            {
                for (int i = 0; i < _channels.Length; i++)
                {
                    _URI = _tvdbURI + _channels[i].ToString();
                    _filePath = defaults.XMLFileStoragePath + Path.GetFileName(_URI);



                    if (FileExists(FileName(_filePath)))
                    {
                        //file exists already, do nothing...
                    }
                    else
                    {
                        //no existing xml file, download
                        int _dataSize = 1024;

                        byte[] data = new byte[_dataSize];
                        Stream writer;


                        //create request to URI

                        WebRequest request = WebRequest.Create(_URI);
                        //get size of file and raise an event, so mainform can start with the progressbar


                        if (request is HttpWebRequest)
                        {
                            ((HttpWebRequest)request).UserAgent = "DuffTV";
                            //((HttpWebRequest)request).TransferEncoding = "iso-8859-1";
                        }

                        if (_useProxy)
                        {
                            WebProxy proxy = new WebProxy(_proxyURI, true);
                            proxy.Credentials = new NetworkCredential(_proxyUser, _proxyPass, _proxyDomain);
                            request.Proxy = proxy;
                        }



                        // Send the 'HttpWebRequest' and wait for response.
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        _ContentLength = (int)response.ContentLength;

                        Stream stream = response.GetResponseStream();

                        if (!File.Exists(_filePath))
                        {
                            writer = File.Create(_filePath);
                        }
                        else
                        {
                            File.Delete(_filePath);
                            writer = File.Create(_filePath);
                        }
                        int count = 0;
                        count = stream.Read(data, 0, _dataSize);
                        while (count > 0)
                        {
                            writer.Write(data, 0, count);
                            count = stream.Read(data, 0, _dataSize);
                        }

                        response.Close();
                        stream.Close();
                        writer.Close();

                        //file done
                    }

                }
                //finished downloading all files, raise event to mainform
                return _channels;
            }
            catch (ThreadAbortException)
            {
                this.Dispose(true);
                return null;
            }
            catch (WebException webEx)
            {
                throw new Exception(String.Format("Error downloading listings. {0}", webEx.Status));
                return null;
            }
            catch (IOException ioEx)
            {
                throw new Exception(String.Format("Error downloading listings. {0}", ioEx.Message));
                return null;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
                throw new Exception(String.Format("Error downloading listings. {0}", str));
                return null;

            }

        }
    }
}
