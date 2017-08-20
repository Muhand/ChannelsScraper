using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using ChannelsScraper.Extensions;
using System.IO;

namespace ChannelsScraper
{
    public struct Channel
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string ChannelCategory { get; set; }
    }

    public partial class channelsScraper : Form
    {
        private DataTable _channelsDataTable;
        HtmlWeb _web;
        public channelsScraper()
        {
            InitializeComponent();
            InitTable();
            _web = new HtmlWeb();
        }

        private async void scrapeBtn_Click(object sender, EventArgs e)
        {
            if (sourcesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a source before scraping");
                saveBtn.Enabled = false;
            }
            else
            {
                Application.UseWaitCursor = true;

                var channels = await ChannelsFromJanBeryan("http://beitsports.blogspot.de/p/adsbygoogle-window.html");

                if (channels.Count == 0)
                {
                    MessageBox.Show("No channels were found");
                    channelsFound.Text = "0 channels were found.";
                    saveBtn.Enabled = false;
                }
                else
                {

                    foreach (var channel in channels)
                    {
                        //channel.URL = channel.URL.Split(new char[] { '=' },2,StringSplitOptions.RemoveEmptyEntries)[1];
                        _channelsDataTable.Rows.Add(channel.Name, channel.URL, channel.ChannelCategory);
                        channelsFound.Text = _channelsDataTable.Rows.Count.ToString() + " channels were found.";
                    }
                    saveBtn.Enabled = true;
                }
                Application.UseWaitCursor = false;
            }

        }
        private async Task<List<Channel>> ChannelsFromJanBeryan(string websiteURL)
        {
            List<string> categories = new List<string>();
            List<Channel> channels = new List<Channel>();
            var catWebPageDoc = await Task.Factory.StartNew(() => _web.Load(websiteURL));
            var catNodes = catWebPageDoc.DocumentNode.SelectNodes("//*[@id=\"Blog1\"]//div//div//div//div//div//h2//span//span//div//a");
            var categoryURL = catNodes.Select(node => node.Attributes[0].Value);
            categories = categoryURL.ToList();

            if (categories.Count == 0)
                return new List<Channel>();

            foreach (var cat in categories)
            {
                var chWebPageDoc = await Task.Factory.StartNew(() => _web.Load(cat));
                var chNodes = chWebPageDoc.DocumentNode.SelectNodes("//*[@id=\"Blog1\"]//div//div//div//div//div//div//h2//span//span//a | //*[@id=\"Blog1\"]//div//div//div//div//div//h2//span//span//a | //*[@id=\"Blog1\"]//div//div//div//div//h2//span//span//a | //*[@id=\"Blog1\"]//div//div//div//div//div//div//h2//a");
                var catNameNodes = chWebPageDoc.DocumentNode.SelectNodes("//*[@id=\"Blog1\"]/div/div[3]/div/div[1]/span/b | //*[@id=\"Blog1\"]/div/div[3]/div/div/div[1]/b/span | //*[@id=\"Blog1\"]/div/div[3]/div/div[1]/b/span");
                //| //*[@id=\"Blog1\"]//div//div//div//div//span//b | //*[@id=\"Blog1\"]//div//div//div//div//div//b//span | //*[@id=\"Blog1\"]//div//div//div//div//b//span
                var channelCat = catNameNodes.Select(node => node.InnerText);
                var channelsName = chNodes.Select(node => node.InnerText);
                var tempChannelsURL = chNodes.Select(node => node.Attributes[0].Value);
                List<string> channelsURL = new List<string>();

                foreach (var item in tempChannelsURL)
                {
                    var temp = item.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    channelsURL.Add(temp[1]);
                }


                //If there are not data in channelsName or channelsURL then return empty list
                if (channelsName != null && channelsURL != null && channelCat != null)
                {
                    if(channelCat.ToList().Count>2)
                        channels.AddRange(channelsName.ZipThree(channelsURL, channelCat.ToList(), (channelName, channelUrl, channelCate)
                            => new Channel() { Name = channelName, URL = channelUrl, ChannelCategory = channelCate }).ToList());
                    else
                        channels.AddRange(channelsName.Zip(channelsURL, (channelName, channelURL) => new Channel() { Name = channelName, URL = channelURL, ChannelCategory = channelCat.ToList()[0] }).ToList());
                }
            }

            return channels;
        }

        /// <summary>
        /// Initialize DataTable for channels
        /// </summary>
        private void InitTable()
        {
            _channelsDataTable = new DataTable("ChannelsDataTable");
            _channelsDataTable.Columns.Add("Channel Name", typeof(string));
            _channelsDataTable.Columns.Add("Channel URL", typeof(string));
            _channelsDataTable.Columns.Add("Category", typeof(string));
            channelsDataGridViewer.DataSource = _channelsDataTable;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(channelsDataGridViewer.Rows.Count >1)
            {
                progressBar1.Maximum = channelsDataGridViewer.Rows.Count;
                progressBar1.Value = 0;

                var fileName = "channels.m3u";
                var directoryName = DateTime.Today.ToString("MM-dd-yyyy");

                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(directoryName+"/"+fileName))
                {
                    file.WriteLine("#EXTM3U");


                    foreach (DataGridViewRow row in channelsDataGridViewer.Rows)
                    {
                        for (int i = 0; i < channelsDataGridViewer.Columns.Count; i++)
                        {
                            try
                            {
                                string cellText = row.Cells[i].Value.ToString();
                                if (i == 0)
                                    file.WriteLine("#EXTINF:-1," + cellText);
                                else if (i == 1)
                                    file.WriteLine(cellText);

                            }
                            catch (NullReferenceException)
                            {

                            }
                        }
                        progressBar1.Value++;
                    }
                    MessageBox.Show("All channels were written to channels.m3u");
                }
            }
            else
            {
                MessageBox.Show("There are no channels added to the list, please make sure to scrape first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saveBtn.Enabled = false;
            }
        }
    }
}
