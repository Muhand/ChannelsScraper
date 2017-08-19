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

namespace ChannelsScraper
{

    public class Channel
    {
        public string Name { get; set; }
        public string URL { get; set; }
    }

    public partial class ChannelsScraper : Form
    {
        private DataTable _channelsDataTable;
        HtmlWeb _web;
        public ChannelsScraper()
        {
            InitializeComponent();
            InitTable();
            _web = new HtmlWeb();
        }

        private async void ChannelsScraper_LoadAsync(object sender, EventArgs e)
        {
            //loadWeb("http://beitsports.blogspot.de/p/adsbygoogle-window_18.html");
            var channels = await ChannelsFromPage("http://beitsports.blogspot.de/p/adsbygoogle-window_18.html");

            foreach (var channel in channels)
            {
                _channelsDataTable.Rows.Add(channel.Name, channel.URL);
            }
        }

        private async Task<List<Channel>> ChannelsFromPage(string websiteURL)
        {
            var webPageDoc = await Task.Factory.StartNew(() => _web.Load(websiteURL));
            var nodes = webPageDoc.DocumentNode.SelectNodes("//*[@id=\"Blog1\"]//div//div//div//div//div//div//h2//span//span//a");
            var channelsName = nodes.Select(node => node.InnerText);
            var channelsURL = nodes.Select(node => node.Attributes[0].Value);

            //If there are not data in channelsName or channelsURL then return empty list
            if (channelsName == null || channelsURL == null)
                return new List<Channel>();
            
            return channelsName.Zip(channelsURL, (channelName, channelURL) => new Channel() { Name = channelName, URL = channelURL, }).ToList();
        }

        /// <summary>
        /// Initialize DataTable for channels
        /// </summary>
        private void InitTable()
        {
            _channelsDataTable = new DataTable("ChannelsDataTable");
            _channelsDataTable.Columns.Add("Channel Name", typeof(string));
            _channelsDataTable.Columns.Add("Channel URL", typeof(string));
            channelsDataGridViewer.DataSource = _channelsDataTable;
        }



    }
}
