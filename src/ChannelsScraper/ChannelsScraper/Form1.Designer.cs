namespace ChannelsScraper
{
    partial class channelsScraper
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.scrapeBtn = new System.Windows.Forms.Button();
            this.sourcesComboBox = new System.Windows.Forms.ComboBox();
            this.channelsDataGridViewer = new System.Windows.Forms.DataGridView();
            this.channelsFound = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelsDataGridViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.channelsFound);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.saveBtn);
            this.splitContainer1.Panel1.Controls.Add(this.scrapeBtn);
            this.splitContainer1.Panel1.Controls.Add(this.sourcesComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.channelsDataGridViewer);
            this.splitContainer1.Size = new System.Drawing.Size(866, 663);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select source to scrape:";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(626, 14);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(130, 33);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // scrapeBtn
            // 
            this.scrapeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrapeBtn.Location = new System.Drawing.Point(490, 14);
            this.scrapeBtn.Name = "scrapeBtn";
            this.scrapeBtn.Size = new System.Drawing.Size(130, 33);
            this.scrapeBtn.TabIndex = 1;
            this.scrapeBtn.Text = "scrape";
            this.scrapeBtn.UseVisualStyleBackColor = true;
            this.scrapeBtn.Click += new System.EventHandler(this.scrapeBtn_Click);
            // 
            // sourcesComboBox
            // 
            this.sourcesComboBox.FormattingEnabled = true;
            this.sourcesComboBox.Items.AddRange(new object[] {
            "www.janberyan.com"});
            this.sourcesComboBox.Location = new System.Drawing.Point(175, 19);
            this.sourcesComboBox.Name = "sourcesComboBox";
            this.sourcesComboBox.Size = new System.Drawing.Size(309, 24);
            this.sourcesComboBox.TabIndex = 0;
            // 
            // channelsDataGridViewer
            // 
            this.channelsDataGridViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.channelsDataGridViewer.Location = new System.Drawing.Point(0, 0);
            this.channelsDataGridViewer.Name = "channelsDataGridViewer";
            this.channelsDataGridViewer.ReadOnly = true;
            this.channelsDataGridViewer.RowTemplate.Height = 24;
            this.channelsDataGridViewer.Size = new System.Drawing.Size(866, 518);
            this.channelsDataGridViewer.TabIndex = 0;
            // 
            // channelsFound
            // 
            this.channelsFound.AutoSize = true;
            this.channelsFound.Location = new System.Drawing.Point(12, 54);
            this.channelsFound.Name = "channelsFound";
            this.channelsFound.Size = new System.Drawing.Size(0, 17);
            this.channelsFound.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 538);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(842, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // channelsScraper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 663);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "channelsScraper";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Channels Scraper";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.channelsDataGridViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button scrapeBtn;
        private System.Windows.Forms.ComboBox sourcesComboBox;
        private System.Windows.Forms.DataGridView channelsDataGridViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label channelsFound;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

