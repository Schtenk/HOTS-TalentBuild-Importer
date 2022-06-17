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
            this.TimeframeLbl = new System.Windows.Forms.Label();
            this.AllRanksChkBox = new System.Windows.Forms.CheckBox();
            this.HeroesBox = new System.Windows.Forms.CheckedListBox();
            this.AllHeroesChkBox = new System.Windows.Forms.CheckBox();
            this.Build1Box = new System.Windows.Forms.ComboBox();
            this.RanksBox = new System.Windows.Forms.CheckedListBox();
            this.BackupBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Build3Box = new System.Windows.Forms.ComboBox();
            this.Build2Lbl = new System.Windows.Forms.Label();
            this.Build2Box = new System.Windows.Forms.ComboBox();
            this.BuildLbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FetcherWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.RestartBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImportBtn
            // 
            this.ImportBtn.Location = new System.Drawing.Point(297, 314);
            this.ImportBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(225, 53);
            this.ImportBtn.TabIndex = 0;
            this.ImportBtn.Text = "Import";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // TimeframeLbl
            // 
            this.TimeframeLbl.Location = new System.Drawing.Point(0, 0);
            this.TimeframeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeframeLbl.Name = "TimeframeLbl";
            this.TimeframeLbl.Size = new System.Drawing.Size(117, 27);
            this.TimeframeLbl.TabIndex = 14;
            // 
            // AllRanksChkBox
            // 
            this.AllRanksChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.AllRanksChkBox.Location = new System.Drawing.Point(297, 10);
            this.AllRanksChkBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AllRanksChkBox.Name = "AllRanksChkBox";
            this.AllRanksChkBox.Size = new System.Drawing.Size(225, 27);
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
            this.HeroesBox.Location = new System.Drawing.Point(14, 44);
            this.HeroesBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.HeroesBox.Name = "HeroesBox";
            this.HeroesBox.Size = new System.Drawing.Size(275, 598);
            this.HeroesBox.TabIndex = 8;
            this.HeroesBox.SelectedIndexChanged += new System.EventHandler(this.HeroesBox_SelectedIndexChanged);
            // 
            // AllHeroesChkBox
            // 
            this.AllHeroesChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.AllHeroesChkBox.Location = new System.Drawing.Point(14, 10);
            this.AllHeroesChkBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AllHeroesChkBox.Name = "AllHeroesChkBox";
            this.AllHeroesChkBox.Size = new System.Drawing.Size(275, 27);
            this.AllHeroesChkBox.TabIndex = 9;
            this.AllHeroesChkBox.Text = "All Heroes";
            this.AllHeroesChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AllHeroesChkBox.UseVisualStyleBackColor = true;
            this.AllHeroesChkBox.CheckedChanged += new System.EventHandler(this.AllHeroesChkBox_CheckedChanged);
            // 
            // Build1Box
            // 
            this.Build1Box.FormattingEnabled = true;
            this.Build1Box.Location = new System.Drawing.Point(6, 37);
            this.Build1Box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Build1Box.Name = "Build1Box";
            this.Build1Box.Size = new System.Drawing.Size(212, 23);
            this.Build1Box.TabIndex = 10;
            this.Build1Box.Tag = "0";
            // 
            // RanksBox
            // 
            this.RanksBox.CheckOnClick = true;
            this.RanksBox.FormattingEnabled = true;
            this.RanksBox.Location = new System.Drawing.Point(297, 44);
            this.RanksBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RanksBox.Name = "RanksBox";
            this.RanksBox.Size = new System.Drawing.Size(225, 94);
            this.RanksBox.TabIndex = 0;
            this.RanksBox.SelectedIndexChanged += new System.EventHandler(this.RanksBox_SelectedIndexChanged);
            // 
            // BackupBtn
            // 
            this.BackupBtn.Location = new System.Drawing.Point(297, 596);
            this.BackupBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BackupBtn.Name = "BackupBtn";
            this.BackupBtn.Size = new System.Drawing.Size(225, 46);
            this.BackupBtn.TabIndex = 15;
            this.BackupBtn.Text = "Backup TalentBuilds.txt";
            this.BackupBtn.UseVisualStyleBackColor = true;
            this.BackupBtn.Click += new System.EventHandler(this.BackupBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Build3Box);
            this.groupBox1.Controls.Add(this.Build2Lbl);
            this.groupBox1.Controls.Add(this.Build2Box);
            this.groupBox1.Controls.Add(this.BuildLbl1);
            this.groupBox1.Controls.Add(this.Build1Box);
            this.groupBox1.Location = new System.Drawing.Point(297, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 164);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Builds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Build 3:";
            // 
            // Build3Box
            // 
            this.Build3Box.FormattingEnabled = true;
            this.Build3Box.Location = new System.Drawing.Point(6, 125);
            this.Build3Box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Build3Box.Name = "Build3Box";
            this.Build3Box.Size = new System.Drawing.Size(212, 23);
            this.Build3Box.TabIndex = 23;
            this.Build3Box.Tag = "2";
            // 
            // Build2Lbl
            // 
            this.Build2Lbl.AutoSize = true;
            this.Build2Lbl.Location = new System.Drawing.Point(6, 63);
            this.Build2Lbl.Name = "Build2Lbl";
            this.Build2Lbl.Size = new System.Drawing.Size(46, 15);
            this.Build2Lbl.TabIndex = 22;
            this.Build2Lbl.Text = "Build 2:";
            // 
            // Build2Box
            // 
            this.Build2Box.FormattingEnabled = true;
            this.Build2Box.Location = new System.Drawing.Point(6, 81);
            this.Build2Box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Build2Box.Name = "Build2Box";
            this.Build2Box.Size = new System.Drawing.Size(212, 23);
            this.Build2Box.TabIndex = 21;
            this.Build2Box.Tag = "1";
            // 
            // BuildLbl1
            // 
            this.BuildLbl1.AutoSize = true;
            this.BuildLbl1.Location = new System.Drawing.Point(6, 19);
            this.BuildLbl1.Name = "BuildLbl1";
            this.BuildLbl1.Size = new System.Drawing.Size(46, 15);
            this.BuildLbl1.TabIndex = 20;
            this.BuildLbl1.Text = "Build 1:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(297, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 54);
            this.label1.TabIndex = 20;
            this.label1.Text = "\"Unchanged\" option will set Build# to what it was in \"TalentBuilds.txt\" when this" +
    " program started.";
            // 
            // FetcherWorker
            // 
            this.FetcherWorker.WorkerReportsProgress = true;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(297, 567);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(225, 23);
            this.ProgressBar.TabIndex = 21;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(297, 549);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 15);
            this.StatusLabel.TabIndex = 22;
            // 
            // RestartBtn
            // 
            this.RestartBtn.Enabled = false;
            this.RestartBtn.Location = new System.Drawing.Point(442, 541);
            this.RestartBtn.Name = "RestartBtn";
            this.RestartBtn.Size = new System.Drawing.Size(80, 23);
            this.RestartBtn.TabIndex = 23;
            this.RestartBtn.Text = "Restart Now";
            this.RestartBtn.UseVisualStyleBackColor = true;
            this.RestartBtn.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 661);
            this.Controls.Add(this.RestartBtn);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BackupBtn);
            this.Controls.Add(this.RanksBox);
            this.Controls.Add(this.AllHeroesChkBox);
            this.Controls.Add(this.HeroesBox);
            this.Controls.Add(this.TimeframeLbl);
            this.Controls.Add(this.AllRanksChkBox);
            this.Controls.Add(this.ImportBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Hots TalentBuild Importer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.Label TimeframeLbl;
        private System.Windows.Forms.CheckBox AllRanksChkBox;
        private System.Windows.Forms.CheckBox AllHeroesChkBox;
        private System.Windows.Forms.ComboBox Build1Box;
        public System.Windows.Forms.CheckedListBox HeroesBox;
        private System.Windows.Forms.CheckedListBox RanksBox;
        private System.Windows.Forms.Button BackupBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label BuildLbl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Build3Box;
        private System.Windows.Forms.Label Build2Lbl;
        private System.Windows.Forms.ComboBox Build2Box;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker FetcherWorker;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button RestartBtn;
    }
}

