namespace DuffTv
{
    partial class PrefsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrefsForm));
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tabXMLTV = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.lstChannelList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAutoUpdate = new System.Windows.Forms.ComboBox();
            this.tabPrefs = new System.Windows.Forms.TabControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabAbout.SuspendLayout();
            this.tabXMLTV.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabPrefs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.label7);
            this.tabAbout.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.tabAbout, "tabAbout");
            this.tabAbout.Name = "tabAbout";
            // 
            // tabXMLTV
            // 
            this.tabXMLTV.Controls.Add(this.label6);
            this.tabXMLTV.Controls.Add(this.lstChannelList);
            this.tabXMLTV.Controls.Add(this.cmbSource);
            this.tabXMLTV.Controls.Add(this.cmbCountry);
            this.tabXMLTV.Controls.Add(this.label5);
            this.tabXMLTV.Controls.Add(this.label4);
            resources.ApplyResources(this.tabXMLTV, "tabXMLTV");
            this.tabXMLTV.Name = "tabXMLTV";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cmbCountry
            // 
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cmbSource
            // 
            resources.ApplyResources(this.cmbSource, "cmbSource");
            this.cmbSource.Name = "cmbSource";
            // 
            // lstChannelList
            // 
            resources.ApplyResources(this.lstChannelList, "lstChannelList");
            this.lstChannelList.Name = "lstChannelList";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.cmbAutoUpdate);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.lblLastUpdate);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.lblVersion);
            this.tabGeneral.Controls.Add(this.label1);
            resources.ApplyResources(this.tabGeneral, "tabGeneral");
            this.tabGeneral.Name = "tabGeneral";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblLastUpdate
            // 
            resources.ApplyResources(this.lblLastUpdate, "lblLastUpdate");
            this.lblLastUpdate.Name = "lblLastUpdate";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cmbAutoUpdate
            // 
            this.cmbAutoUpdate.Items.Add(resources.GetString("cmbAutoUpdate.Items"));
            this.cmbAutoUpdate.Items.Add(resources.GetString("cmbAutoUpdate.Items1"));
            this.cmbAutoUpdate.Items.Add(resources.GetString("cmbAutoUpdate.Items2"));
            this.cmbAutoUpdate.Items.Add(resources.GetString("cmbAutoUpdate.Items3"));
            resources.ApplyResources(this.cmbAutoUpdate, "cmbAutoUpdate");
            this.cmbAutoUpdate.Name = "cmbAutoUpdate";
            // 
            // tabPrefs
            // 
            this.tabPrefs.Controls.Add(this.tabGeneral);
            this.tabPrefs.Controls.Add(this.tabXMLTV);
            this.tabPrefs.Controls.Add(this.tabAbout);
            resources.ApplyResources(this.tabPrefs, "tabPrefs");
            this.tabPrefs.Name = "tabPrefs";
            this.tabPrefs.SelectedIndex = 0;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // PrefsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabPrefs);
            this.Name = "PrefsForm";
            this.tabAbout.ResumeLayout(false);
            this.tabXMLTV.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabPrefs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.TabPage tabXMLTV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstChannelList;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.ComboBox cmbAutoUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabPrefs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}