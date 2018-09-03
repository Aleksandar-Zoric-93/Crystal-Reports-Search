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
            ((System.ComponentModel.ISupportInitialize)(this.helpBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBtn
            // 
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Location = new System.Drawing.Point(282, 380);
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
            this.reportNameLbl.Location = new System.Drawing.Point(11, 346);
            this.reportNameLbl.Name = "reportNameLbl";
            this.reportNameLbl.Size = new System.Drawing.Size(0, 13);
            this.reportNameLbl.TabIndex = 3;
            // 
            // reportPathLbl
            // 
            this.reportPathLbl.AutoSize = true;
            this.reportPathLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.reportPathLbl.Location = new System.Drawing.Point(11, 359);
            this.reportPathLbl.Name = "reportPathLbl";
            this.reportPathLbl.Size = new System.Drawing.Size(0, 13);
            this.reportPathLbl.TabIndex = 4;
            // 
            // viewReportBtn
            // 
            this.viewReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewReportBtn.Location = new System.Drawing.Point(598, 380);
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
            this.viewSQLBtn.Location = new System.Drawing.Point(517, 380);
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
            this.foundSearchTxt.Location = new System.Drawing.Point(15, 67);
            this.foundSearchTxt.Name = "foundSearchTxt";
            this.foundSearchTxt.ReadOnly = true;
            this.foundSearchTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.foundSearchTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.foundSearchTxt.Size = new System.Drawing.Size(658, 264);
            this.foundSearchTxt.TabIndex = 8;
            this.foundSearchTxt.Text = "";
            // 
            // copyBtn
            // 
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Location = new System.Drawing.Point(12, 380);
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
            this.copyLbl.Location = new System.Drawing.Point(11, 405);
            this.copyLbl.Name = "copyLbl";
            this.copyLbl.Size = new System.Drawing.Size(0, 13);
            this.copyLbl.TabIndex = 10;
            this.copyLbl.Visible = false;
            // 
            // copyrightLbl
            // 
            this.copyrightLbl.AutoSize = true;
            this.copyrightLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.copyrightLbl.Location = new System.Drawing.Point(257, 406);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 421);
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
    }
}

