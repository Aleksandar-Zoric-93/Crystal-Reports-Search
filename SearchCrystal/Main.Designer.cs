namespace SearchCrystal
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.selReportBtn = new System.Windows.Forms.Button();
            this.reportNameLbl = new System.Windows.Forms.Label();
            this.reportPathLbl = new System.Windows.Forms.Label();
            this.viewReportBtn = new System.Windows.Forms.Button();
            this.viewSQLBtn = new System.Windows.Forms.Button();
            this.foundSearchTxt = new System.Windows.Forms.RichTextBox();
            this.copyBtn = new System.Windows.Forms.Button();
            this.copyLbl = new System.Windows.Forms.Label();
            this.copyrightLbl = new System.Windows.Forms.Label();
            this.helpBox = new System.Windows.Forms.PictureBox();
            this.versionLbl = new System.Windows.Forms.Label();
            this.commandNamesTxt = new System.Windows.Forms.RichTextBox();
            this.multiSelChk = new System.Windows.Forms.CheckBox();
            this.multiAddBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBtn
            // 
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Location = new System.Drawing.Point(282, 408);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(120, 23);
            this.searchBtn.TabIndex = 0;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(156, 41);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(370, 20);
            this.searchTxt.TabIndex = 1;
            // 
            // selReportBtn
            // 
            this.selReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selReportBtn.Location = new System.Drawing.Point(282, 12);
            this.selReportBtn.Name = "selReportBtn";
            this.selReportBtn.Size = new System.Drawing.Size(120, 23);
            this.selReportBtn.TabIndex = 2;
            this.selReportBtn.Text = "Select Report";
            this.selReportBtn.UseVisualStyleBackColor = true;
            this.selReportBtn.Click += new System.EventHandler(this.selReportBtn_Click);
            // 
            // reportNameLbl
            // 
            this.reportNameLbl.AutoSize = true;
            this.reportNameLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.reportNameLbl.Location = new System.Drawing.Point(11, 376);
            this.reportNameLbl.Name = "reportNameLbl";
            this.reportNameLbl.Size = new System.Drawing.Size(0, 13);
            this.reportNameLbl.TabIndex = 3;
            // 
            // reportPathLbl
            // 
            this.reportPathLbl.AutoSize = true;
            this.reportPathLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.reportPathLbl.Location = new System.Drawing.Point(11, 389);
            this.reportPathLbl.Name = "reportPathLbl";
            this.reportPathLbl.Size = new System.Drawing.Size(0, 13);
            this.reportPathLbl.TabIndex = 4;
            // 
            // viewReportBtn
            // 
            this.viewReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewReportBtn.Location = new System.Drawing.Point(598, 408);
            this.viewReportBtn.Name = "viewReportBtn";
            this.viewReportBtn.Size = new System.Drawing.Size(75, 23);
            this.viewReportBtn.TabIndex = 6;
            this.viewReportBtn.Text = "View Report";
            this.viewReportBtn.UseVisualStyleBackColor = true;
            this.viewReportBtn.Click += new System.EventHandler(this.viewReportBtn_Click);
            // 
            // viewSQLBtn
            // 
            this.viewSQLBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewSQLBtn.Location = new System.Drawing.Point(517, 408);
            this.viewSQLBtn.Name = "viewSQLBtn";
            this.viewSQLBtn.Size = new System.Drawing.Size(75, 23);
            this.viewSQLBtn.TabIndex = 7;
            this.viewSQLBtn.Text = "View SQL";
            this.viewSQLBtn.UseVisualStyleBackColor = true;
            this.viewSQLBtn.Click += new System.EventHandler(this.viewSQLBtn_Click);
            // 
            // foundSearchTxt
            // 
            this.foundSearchTxt.BackColor = System.Drawing.Color.White;
            this.foundSearchTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.foundSearchTxt.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foundSearchTxt.Location = new System.Drawing.Point(14, 67);
            this.foundSearchTxt.Name = "foundSearchTxt";
            this.foundSearchTxt.ReadOnly = true;
            this.foundSearchTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.foundSearchTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.foundSearchTxt.Size = new System.Drawing.Size(659, 213);
            this.foundSearchTxt.TabIndex = 8;
            this.foundSearchTxt.Text = "";
            // 
            // copyBtn
            // 
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Location = new System.Drawing.Point(12, 408);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 23);
            this.copyBtn.TabIndex = 9;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Visible = false;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // copyLbl
            // 
            this.copyLbl.AutoSize = true;
            this.copyLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.copyLbl.Location = new System.Drawing.Point(11, 433);
            this.copyLbl.Name = "copyLbl";
            this.copyLbl.Size = new System.Drawing.Size(0, 13);
            this.copyLbl.TabIndex = 10;
            this.copyLbl.Visible = false;
            // 
            // copyrightLbl
            // 
            this.copyrightLbl.AutoSize = true;
            this.copyrightLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.copyrightLbl.Location = new System.Drawing.Point(257, 434);
            this.copyrightLbl.Name = "copyrightLbl";
            this.copyrightLbl.Size = new System.Drawing.Size(167, 13);
            this.copyrightLbl.TabIndex = 11;
            this.copyrightLbl.Text = "Icons by Freepik and SmashIcons";
            // 
            // helpBox
            // 
            this.helpBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpBox.Image = global::SearchCrystal.Properties.Resources.info;
            this.helpBox.Location = new System.Drawing.Point(645, 12);
            this.helpBox.Name = "helpBox";
            this.helpBox.Size = new System.Drawing.Size(28, 33);
            this.helpBox.TabIndex = 12;
            this.helpBox.TabStop = false;
            this.helpBox.Click += new System.EventHandler(this.helpBox_Click);
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Location = new System.Drawing.Point(628, 434);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(46, 13);
            this.versionLbl.TabIndex = 13;
            this.versionLbl.Text = "0.0.0.38";
            // 
            // commandNamesTxt
            // 
            this.commandNamesTxt.BackColor = System.Drawing.Color.White;
            this.commandNamesTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commandNamesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandNamesTxt.Location = new System.Drawing.Point(14, 289);
            this.commandNamesTxt.Name = "commandNamesTxt";
            this.commandNamesTxt.ReadOnly = true;
            this.commandNamesTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.commandNamesTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.commandNamesTxt.Size = new System.Drawing.Size(659, 55);
            this.commandNamesTxt.TabIndex = 14;
            this.commandNamesTxt.Text = "";
            // 
            // multiSelChk
            // 
            this.multiSelChk.AutoSize = true;
            this.multiSelChk.Location = new System.Drawing.Point(14, 12);
            this.multiSelChk.Name = "multiSelChk";
            this.multiSelChk.Size = new System.Drawing.Size(81, 17);
            this.multiSelChk.TabIndex = 15;
            this.multiSelChk.Text = "Multi-Select";
            this.multiSelChk.UseVisualStyleBackColor = true;
            this.multiSelChk.CheckedChanged += new System.EventHandler(this.multiSelChk_CheckedChanged);
            // 
            // multiAddBtn
            // 
            this.multiAddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiAddBtn.Location = new System.Drawing.Point(14, 35);
            this.multiAddBtn.Name = "multiAddBtn";
            this.multiAddBtn.Size = new System.Drawing.Size(75, 23);
            this.multiAddBtn.TabIndex = 16;
            this.multiAddBtn.Text = "Add Report";
            this.multiAddBtn.UseVisualStyleBackColor = true;
            this.multiAddBtn.Visible = false;
            this.multiAddBtn.Click += new System.EventHandler(this.multiAddBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 453);
            this.Controls.Add(this.multiAddBtn);
            this.Controls.Add(this.multiSelChk);
            this.Controls.Add(this.commandNamesTxt);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.helpBox);
            this.Controls.Add(this.copyrightLbl);
            this.Controls.Add(this.copyLbl);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.foundSearchTxt);
            this.Controls.Add(this.viewSQLBtn);
            this.Controls.Add(this.viewReportBtn);
            this.Controls.Add(this.reportPathLbl);
            this.Controls.Add(this.reportNameLbl);
            this.Controls.Add(this.selReportBtn);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.searchBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crystal Reports Search";
            ((System.ComponentModel.ISupportInitialize)(this.helpBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Button selReportBtn;
        private System.Windows.Forms.Label reportNameLbl;
        private System.Windows.Forms.Label reportPathLbl;
        private System.Windows.Forms.Button viewReportBtn;
        private System.Windows.Forms.Button viewSQLBtn;
        private System.Windows.Forms.RichTextBox foundSearchTxt;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Label copyLbl;
        private System.Windows.Forms.Label copyrightLbl;
        private System.Windows.Forms.PictureBox helpBox;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.RichTextBox commandNamesTxt;
        private System.Windows.Forms.CheckBox multiSelChk;
        private System.Windows.Forms.Button multiAddBtn;
    }
}

