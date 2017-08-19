namespace ChannelsScraper
{
    partial class ChannelsScraper
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
            this.channelsDataGridViewer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.channelsDataGridViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // channelsDataGridViewer
            // 
            this.channelsDataGridViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.channelsDataGridViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelsDataGridViewer.Location = new System.Drawing.Point(0, 0);
            this.channelsDataGridViewer.Name = "channelsDataGridViewer";
            this.channelsDataGridViewer.RowTemplate.Height = 24;
            this.channelsDataGridViewer.Size = new System.Drawing.Size(903, 596);
            this.channelsDataGridViewer.TabIndex = 0;
            // 
            // ChannelsScraper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 596);
            this.Controls.Add(this.channelsDataGridViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChannelsScraper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Channels Scraper";
            this.Load += new System.EventHandler(this.ChannelsScraper_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.channelsDataGridViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView channelsDataGridViewer;
    }
}

