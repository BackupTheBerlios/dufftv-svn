using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DuffTv.Configurator;


namespace DuffTv
{
    public partial class PrefsForm : Form
    {
        //initialize our config object
        private Config _prefs = new Config();

        //initialize local variables which will hold our config parameters
        private string _Version;
        private Boolean _AutoUpdate;
        private string _XMLTVSourceURI;
        private string _Country;
        private string _LastUpdate;
        private string[] _ChannelList;
        private ArrayList _Countries;

        public PrefsForm()
        {
            InitializeComponent();
            ReadPrefs();
        }

        

        private void ReadPrefs()
        {
            //read existing prefs from config file
            _Version = _prefs.Version;
            _AutoUpdate = _prefs.AutoUpdate;
            _XMLTVSourceURI = _prefs.XMLTVSourceURI;
            _Country = _prefs.Country;
            _LastUpdate = _prefs.LastUpdate;
            _ChannelList = _prefs.ChannelListNames;
            _Countries = _prefs.Countries;

            //assign prefs to UI
            lblVersion.Text = _Version;
            lblLastUpdate.Text = _LastUpdate;
            
            cmbAutoUpdate.Items.Add(_AutoUpdate.ToString());
            
            cmbCountry.DataSource = _Countries;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "SourceURI";
            cmbCountry.SelectedIndex = 0;

            cmbSource.DataSource = _Countries;
            cmbSource.DisplayMember = "SourceURI";
            cmbSource.ValueMember = "SourceURI";
            cmbSource.SelectedIndex = 0;

            lstChannelList.DataSource = _ChannelList;


        }
    }
}