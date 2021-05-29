namespace HOTS_TalentBuild_Importer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ImportBtn = new System.Windows.Forms.Button();
            this.VersionTypeBox = new System.Windows.Forms.ComboBox();
            this.VersionTypeLbl = new System.Windows.Forms.Label();
            this.TimeframeLbl = new System.Windows.Forms.Label();
            this.AllRanksChkBox = new System.Windows.Forms.CheckBox();
            this.HeroesBox = new System.Windows.Forms.CheckedListBox();
            this.AllHeroesChkBox = new System.Windows.Forms.CheckBox();
            this.NrBuildsBox = new System.Windows.Forms.ComboBox();
            this.NrBuildsLbl = new System.Windows.Forms.Label();
            this.HeroUpdateBtn = new System.Windows.Forms.Button();
            this.RanksBox = new System.Windows.Forms.CheckedListBox();
            this.BackupBtn = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.TalentBuildBgWorker = new System.ComponentModel.BackgroundWorker();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImportBtn
            // 
            this.ImportBtn.Location = new System.Drawing.Point(232, 9);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(138, 46);
            this.ImportBtn.TabIndex = 0;
            this.ImportBtn.Text = "Import";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // VersionTypeBox
            // 
            this.VersionTypeBox.FormattingEnabled = true;
            this.VersionTypeBox.Items.AddRange(new object[] {
            "Minor",
            "Major"});
            this.VersionTypeBox.Location = new System.Drawing.Point(232, 76);
            this.VersionTypeBox.Margin = new System.Windows.Forms.Padding(5);
            this.VersionTypeBox.Name = "VersionTypeBox";
            this.VersionTypeBox.Size = new System.Drawing.Size(138, 21);
            this.VersionTypeBox.TabIndex = 1;
            this.VersionTypeBox.Text = "Minor";
            this.VersionTypeBox.SelectedIndexChanged += new System.EventHandler(this.VersionTypeBox_SelectedIndexChanged);
            // 
            // VersionTypeLbl
            // 
            this.VersionTypeLbl.AutoSize = true;
            this.VersionTypeLbl.Location = new System.Drawing.Point(232, 58);
            this.VersionTypeLbl.Name = "VersionTypeLbl";
            this.VersionTypeLbl.Size = new System.Drawing.Size(45, 13);
            this.VersionTypeLbl.TabIndex = 3;
            this.VersionTypeLbl.Text = "Version:";
            // 
            // TimeframeLbl
            // 
            this.TimeframeLbl.Location = new System.Drawing.Point(0, 0);
            this.TimeframeLbl.Name = "TimeframeLbl";
            this.TimeframeLbl.Size = new System.Drawing.Size(100, 23);
            this.TimeframeLbl.TabIndex = 14;
            // 
            // AllRanksChkBox
            // 
            this.AllRanksChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.AllRanksChkBox.Location = new System.Drawing.Point(232, 105);
            this.AllRanksChkBox.Name = "AllRanksChkBox";
            this.AllRanksChkBox.Size = new System.Drawing.Size(138, 23);
            this.AllRanksChkBox.TabIndex = 0;
            this.AllRanksChkBox.Text = "All Ranks";
            this.AllRanksChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AllRanksChkBox.UseVisualStyleBackColor = true;
            this.AllRanksChkBox.CheckedChanged += new System.EventHandler(this.AllRanksChkBox_CheckedChanged);
            // 
            // HeroesBox
            // 
            this.HeroesBox.CheckOnClick = true;
            this.HeroesBox.FormattingEnabled = true;
            this.HeroesBox.Location = new System.Drawing.Point(12, 38);
            this.HeroesBox.Name = "HeroesBox";
            this.HeroesBox.Size = new System.Drawing.Size(214, 514);
            this.HeroesBox.TabIndex = 8;
            this.HeroesBox.SelectedIndexChanged += new System.EventHandler(this.HeroesBox_SelectedIndexChanged);
            // 
            // AllHeroesChkBox
            // 
            this.AllHeroesChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.AllHeroesChkBox.Location = new System.Drawing.Point(12, 9);
            this.AllHeroesChkBox.Name = "AllHeroesChkBox";
            this.AllHeroesChkBox.Size = new System.Drawing.Size(212, 23);
            this.AllHeroesChkBox.TabIndex = 9;
            this.AllHeroesChkBox.Text = "All Heroes";
            this.AllHeroesChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AllHeroesChkBox.UseVisualStyleBackColor = true;
            this.AllHeroesChkBox.CheckedChanged += new System.EventHandler(this.AllHeroesChkBox_CheckedChanged);
            // 
            // NrBuildsBox
            // 
            this.NrBuildsBox.FormattingEnabled = true;
            this.NrBuildsBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.NrBuildsBox.Location = new System.Drawing.Point(234, 269);
            this.NrBuildsBox.Name = "NrBuildsBox";
            this.NrBuildsBox.Size = new System.Drawing.Size(138, 21);
            this.NrBuildsBox.TabIndex = 10;
            this.NrBuildsBox.Text = "3";
            this.NrBuildsBox.SelectedIndexChanged += new System.EventHandler(this.NrBuildsBox_SelectedIndexChanged);
            // 
            // NrBuildsLbl
            // 
            this.NrBuildsLbl.Location = new System.Drawing.Point(232, 231);
            this.NrBuildsLbl.Name = "NrBuildsLbl";
            this.NrBuildsLbl.Size = new System.Drawing.Size(143, 35);
            this.NrBuildsLbl.TabIndex = 11;
            this.NrBuildsLbl.Text = "Number Of Builds To Import Per Character:";
            // 
            // HeroUpdateBtn
            // 
            this.HeroUpdateBtn.Enabled = false;
            this.HeroUpdateBtn.Location = new System.Drawing.Point(232, 407);
            this.HeroUpdateBtn.Name = "HeroUpdateBtn";
            this.HeroUpdateBtn.Size = new System.Drawing.Size(138, 40);
            this.HeroUpdateBtn.TabIndex = 12;
            this.HeroUpdateBtn.Text = "Update HeroData";
            this.HeroUpdateBtn.UseVisualStyleBackColor = true;
            this.HeroUpdateBtn.Visible = false;
            this.HeroUpdateBtn.Click += new System.EventHandler(this.HeroUpdateBtn_Click);
            // 
            // RanksBox
            // 
            this.RanksBox.CheckOnClick = true;
            this.RanksBox.FormattingEnabled = true;
            this.RanksBox.Items.AddRange(new object[] {
            "Master",
            "Diamond",
            "Platinum",
            "Gold",
            "Silver",
            "Bronze"});
            this.RanksBox.Location = new System.Drawing.Point(235, 134);
            this.RanksBox.Name = "RanksBox";
            this.RanksBox.Size = new System.Drawing.Size(135, 94);
            this.RanksBox.TabIndex = 0;
            this.RanksBox.SelectedIndexChanged += new System.EventHandler(this.RanksBox_SelectedIndexChanged);
            // 
            // BackupBtn
            // 
            this.BackupBtn.Location = new System.Drawing.Point(232, 512);
            this.BackupBtn.Name = "BackupBtn";
            this.BackupBtn.Size = new System.Drawing.Size(138, 40);
            this.BackupBtn.TabIndex = 15;
            this.BackupBtn.Text = "Backup TalentBuilds.txt";
            this.BackupBtn.UseVisualStyleBackColor = true;
            this.BackupBtn.Click += new System.EventHandler(this.BackupBtn_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBar.Location = new System.Drawing.Point(232, 483);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(138, 23);
            this.ProgressBar.TabIndex = 16;
            // 
            // StatusLbl
            // 
            this.StatusLbl.BackColor = System.Drawing.Color.Transparent;
            this.StatusLbl.Location = new System.Drawing.Point(232, 450);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(138, 30);
            this.StatusLbl.TabIndex = 18;
            this.StatusLbl.Text = "Ready To Import";
            this.StatusLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TalentBuildBgWorker
            // 
            this.TalentBuildBgWorker.WorkerReportsProgress = true;
            this.TalentBuildBgWorker.WorkerSupportsCancellation = true;
            this.TalentBuildBgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TalentBuildBgWorker_DoWork);
            this.TalentBuildBgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.TalentBuildBgWorker_ProgressChanged);
            this.TalentBuildBgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.TalentBuildBgWorker_RunWorkerCompleted);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(232, 296);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(138, 40);
            this.CancelBtn.TabIndex = 20;
            this.CancelBtn.Text = "Cancel Import";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.BackupBtn);
            this.Controls.Add(this.RanksBox);
            this.Controls.Add(this.HeroUpdateBtn);
            this.Controls.Add(this.NrBuildsLbl);
            this.Controls.Add(this.NrBuildsBox);
            this.Controls.Add(this.AllHeroesChkBox);
            this.Controls.Add(this.HeroesBox);
            this.Controls.Add(this.TimeframeLbl);
            this.Controls.Add(this.VersionTypeLbl);
            this.Controls.Add(this.VersionTypeBox);
            this.Controls.Add(this.AllRanksChkBox);
            this.Controls.Add(this.ImportBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Hots TalentBuild Importer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.ComboBox VersionTypeBox;
        private System.Windows.Forms.Label VersionTypeLbl;
        private System.Windows.Forms.Label TimeframeLbl;
        private System.Windows.Forms.CheckBox AllRanksChkBox;
        private System.Windows.Forms.CheckBox AllHeroesChkBox;
        private System.Windows.Forms.ComboBox NrBuildsBox;
        private System.Windows.Forms.Label NrBuildsLbl;
        private System.Windows.Forms.Button HeroUpdateBtn;
        public System.Windows.Forms.CheckedListBox HeroesBox;
        private System.Windows.Forms.CheckedListBox RanksBox;
        private System.Windows.Forms.Button BackupBtn;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label StatusLbl;
        private System.ComponentModel.BackgroundWorker TalentBuildBgWorker;
        private System.Windows.Forms.Button CancelBtn;
    }
}

