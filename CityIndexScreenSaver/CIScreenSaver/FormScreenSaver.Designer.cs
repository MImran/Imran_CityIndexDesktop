namespace CIScreenSaver
{
    partial class FormScreenSaver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreenSaver));
            this.buttonResumeWindow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelNews = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNewsArchive = new System.Windows.Forms.Label();
            this.labelNewsLatest = new System.Windows.Forms.Label();
            this.panelLatestNews = new System.Windows.Forms.Panel();
            this.labelNewsHeadlineTime = new System.Windows.Forms.Label();
            this.richTextBoxNewsDetail = new System.Windows.Forms.RichTextBox();
            this.labelNewsHeadLine = new System.Windows.Forms.Label();
            this.panelNewsArchive = new System.Windows.Forms.Panel();
            this.richTextBoxNewsArchiveDetail = new System.Windows.Forms.RichTextBox();
            this.comboBoxNewsArcive = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelNews.SuspendLayout();
            this.panelLatestNews.SuspendLayout();
            this.panelNewsArchive.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonResumeWindow
            // 
            this.buttonResumeWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResumeWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResumeWindow.ForeColor = System.Drawing.Color.Black;
            this.buttonResumeWindow.Location = new System.Drawing.Point(948, 21);
            this.buttonResumeWindow.Name = "buttonResumeWindow";
            this.buttonResumeWindow.Size = new System.Drawing.Size(48, 37);
            this.buttonResumeWindow.TabIndex = 4;
            this.buttonResumeWindow.Text = "Resume My Window";
            this.buttonResumeWindow.UseVisualStyleBackColor = true;
            this.buttonResumeWindow.Click += new System.EventHandler(this.buttonResumeWindow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(7, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(998, 5);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panelNews
            // 
            this.panelNews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNews.Controls.Add(this.label1);
            this.panelNews.Controls.Add(this.labelNewsArchive);
            this.panelNews.Controls.Add(this.labelNewsLatest);
            this.panelNews.Controls.Add(this.panelLatestNews);
            this.panelNews.Controls.Add(this.panelNewsArchive);
            this.panelNews.Location = new System.Drawing.Point(15, 137);
            this.panelNews.Name = "panelNews";
            this.panelNews.Size = new System.Drawing.Size(981, 207);
            this.panelNews.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "|";
            // 
            // labelNewsArchive
            // 
            this.labelNewsArchive.AutoSize = true;
            this.labelNewsArchive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNewsArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewsArchive.ForeColor = System.Drawing.Color.White;
            this.labelNewsArchive.Location = new System.Drawing.Point(107, 9);
            this.labelNewsArchive.Name = "labelNewsArchive";
            this.labelNewsArchive.Size = new System.Drawing.Size(102, 16);
            this.labelNewsArchive.TabIndex = 3;
            this.labelNewsArchive.Text = "News Archive";
            this.labelNewsArchive.Click += new System.EventHandler(this.labelNewsArchive_Click);
            // 
            // labelNewsLatest
            // 
            this.labelNewsLatest.AutoSize = true;
            this.labelNewsLatest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNewsLatest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewsLatest.ForeColor = System.Drawing.Color.Orange;
            this.labelNewsLatest.Location = new System.Drawing.Point(9, 9);
            this.labelNewsLatest.Name = "labelNewsLatest";
            this.labelNewsLatest.Size = new System.Drawing.Size(92, 16);
            this.labelNewsLatest.TabIndex = 0;
            this.labelNewsLatest.Text = "Latest News";
            this.labelNewsLatest.Click += new System.EventHandler(this.labelNewsLatest_Click);
            // 
            // panelLatestNews
            // 
            this.panelLatestNews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLatestNews.Controls.Add(this.labelNewsHeadlineTime);
            this.panelLatestNews.Controls.Add(this.richTextBoxNewsDetail);
            this.panelLatestNews.Controls.Add(this.labelNewsHeadLine);
            this.panelLatestNews.Location = new System.Drawing.Point(10, 26);
            this.panelLatestNews.Name = "panelLatestNews";
            this.panelLatestNews.Size = new System.Drawing.Size(954, 176);
            this.panelLatestNews.TabIndex = 4;
            // 
            // labelNewsHeadlineTime
            // 
            this.labelNewsHeadlineTime.AutoSize = true;
            this.labelNewsHeadlineTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewsHeadlineTime.ForeColor = System.Drawing.Color.Gold;
            this.labelNewsHeadlineTime.Location = new System.Drawing.Point(10, 7);
            this.labelNewsHeadlineTime.Name = "labelNewsHeadlineTime";
            this.labelNewsHeadlineTime.Size = new System.Drawing.Size(0, 13);
            this.labelNewsHeadlineTime.TabIndex = 4;
            // 
            // richTextBoxNewsDetail
            // 
            this.richTextBoxNewsDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxNewsDetail.BackColor = System.Drawing.Color.Black;
            this.richTextBoxNewsDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxNewsDetail.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBoxNewsDetail.Location = new System.Drawing.Point(7, 21);
            this.richTextBoxNewsDetail.Name = "richTextBoxNewsDetail";
            this.richTextBoxNewsDetail.ReadOnly = true;
            this.richTextBoxNewsDetail.Size = new System.Drawing.Size(940, 152);
            this.richTextBoxNewsDetail.TabIndex = 3;
            this.richTextBoxNewsDetail.Text = "";
            // 
            // labelNewsHeadLine
            // 
            this.labelNewsHeadLine.AutoSize = true;
            this.labelNewsHeadLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewsHeadLine.ForeColor = System.Drawing.Color.White;
            this.labelNewsHeadLine.Location = new System.Drawing.Point(130, 4);
            this.labelNewsHeadLine.Name = "labelNewsHeadLine";
            this.labelNewsHeadLine.Size = new System.Drawing.Size(0, 16);
            this.labelNewsHeadLine.TabIndex = 1;
            // 
            // panelNewsArchive
            // 
            this.panelNewsArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNewsArchive.Controls.Add(this.richTextBoxNewsArchiveDetail);
            this.panelNewsArchive.Controls.Add(this.comboBoxNewsArcive);
            this.panelNewsArchive.Location = new System.Drawing.Point(10, 28);
            this.panelNewsArchive.Name = "panelNewsArchive";
            this.panelNewsArchive.Size = new System.Drawing.Size(954, 176);
            this.panelNewsArchive.TabIndex = 6;
            // 
            // richTextBoxNewsArchiveDetail
            // 
            this.richTextBoxNewsArchiveDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxNewsArchiveDetail.BackColor = System.Drawing.Color.Black;
            this.richTextBoxNewsArchiveDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxNewsArchiveDetail.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBoxNewsArchiveDetail.Location = new System.Drawing.Point(7, 26);
            this.richTextBoxNewsArchiveDetail.Name = "richTextBoxNewsArchiveDetail";
            this.richTextBoxNewsArchiveDetail.ReadOnly = true;
            this.richTextBoxNewsArchiveDetail.Size = new System.Drawing.Size(940, 145);
            this.richTextBoxNewsArchiveDetail.TabIndex = 4;
            this.richTextBoxNewsArchiveDetail.Text = "";
            // 
            // comboBoxNewsArcive
            // 
            this.comboBoxNewsArcive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxNewsArcive.BackColor = System.Drawing.Color.Black;
            this.comboBoxNewsArcive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNewsArcive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNewsArcive.ForeColor = System.Drawing.Color.Orange;
            this.comboBoxNewsArcive.FormattingEnabled = true;
            this.comboBoxNewsArcive.Items.AddRange(new object[] {
            "hello"});
            this.comboBoxNewsArcive.Location = new System.Drawing.Point(4, 2);
            this.comboBoxNewsArcive.Name = "comboBoxNewsArcive";
            this.comboBoxNewsArcive.Size = new System.Drawing.Size(943, 21);
            this.comboBoxNewsArcive.TabIndex = 3;
            this.comboBoxNewsArcive.SelectedIndexChanged += new System.EventHandler(this.comboBoxNewsArcive_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 276);
            this.panel1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(768, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormScreenSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1017, 663);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelNews);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonResumeWindow);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormScreenSaver";
            this.Text = "Screen Saver";
            this.Load += new System.EventHandler(this.FormScreenSaver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelNews.ResumeLayout(false);
            this.panelNews.PerformLayout();
            this.panelLatestNews.ResumeLayout(false);
            this.panelLatestNews.PerformLayout();
            this.panelNewsArchive.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonResumeWindow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelNews;
        private System.Windows.Forms.Label labelNewsHeadLine;
        private System.Windows.Forms.Label labelNewsLatest;
        private System.Windows.Forms.Label labelNewsArchive;
        private System.Windows.Forms.Panel panelLatestNews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelNewsArchive;
        private System.Windows.Forms.ComboBox comboBoxNewsArcive;
        private System.Windows.Forms.RichTextBox richTextBoxNewsDetail;
        private System.Windows.Forms.Label labelNewsHeadlineTime;
        private System.Windows.Forms.RichTextBox richTextBoxNewsArchiveDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

