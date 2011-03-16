using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CityIndexHelper;
using CIAPI.DTO;
using StreamingClient;
using CIAPI.Streaming;
using System.Threading;
using System.Text.RegularExpressions;
using CityIndexHelper.ScreensaverStructures;


namespace CIScreenSaver
{
    public partial class FormScreenSaver : Form
    {
        public FormScreenSaver(int displayScreen)
        {
            InitializeComponent();

            screenNumber = displayScreen;
        }

        CIAPI_NewsTicker newsTicker;
        Thread newsTickerThread;

        private int screenNumber;
        private News news;
        BindingList<News> newsList;


        private void FormScreenSaver_Load(object sender, EventArgs e)
        {
            loadAndApplySettings();

            newsTicker = new CIAPI_NewsTicker();
            newsTicker.NewsReceived += new EventHandler<NewsReceivedArgs>(newsTicker_NewsReceived);
            newsTickerThread = new Thread(new ThreadStart(newsTicker.SubscribeToNewsHeadlineStream));
            newsTickerThread.Start();
        }

        private void loadAndApplySettings()
        {
            this.Bounds = Screen.AllScreens[screenNumber].Bounds;
            //TopMost = true;

            newsList = new BindingList<News>();
            this.comboBoxNewsArcive.DataSource = newsList;
            this.comboBoxNewsArcive.DisplayMember = "Headline";
        }

        void newsTicker_NewsReceived(object sender, NewsReceivedArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    newsTicker_NewsReceived(sender, e);
                });
                return;
            }

            news = new News();
            news.Headline = "[" + e.NewsDetail.PublishDate.ToShortDateString() + "--" + e.NewsDetail.PublishDate.ToShortTimeString()
                + "]   " + e.NewsDetail.Headline;
            news.Detail = Regex.Replace(e.NewsDetail.Story, "<.*?>", string.Empty).Trim();
            newsList.Add(news);

            this.labelNewsHeadlineTime.Text = e.NewsDetail.PublishDate.ToShortDateString() + "--" + e.NewsDetail.PublishDate.ToShortTimeString();
            this.labelNewsHeadLine.Text = e.NewsDetail.Headline;
            this.richTextBoxNewsDetail.Text = Regex.Replace(e.NewsDetail.Story, "<.*?>", string.Empty).Trim();

            if (this.comboBoxNewsArcive.SelectedIndex == 0)
            {
                this.richTextBoxNewsArchiveDetail.Text = newsList[comboBoxNewsArcive.SelectedIndex].Detail;
            }
        }

        private void buttonResumeWindow_Click(object sender, EventArgs e)
        {
            newsTicker.UnSubscribeNewsHeadLineStream();
            newsTickerThread.Abort();
            this.Close();
        }

        private void labelNewsLatest_Click(object sender, EventArgs e)
        {
            this.panelLatestNews.BringToFront();
            this.labelNewsLatest.ForeColor = Color.Orange;
            this.labelNewsArchive.ForeColor = Color.White;
        }

        private void labelNewsArchive_Click(object sender, EventArgs e)
        {
            this.panelNewsArchive.BringToFront();
            this.labelNewsLatest.ForeColor = Color.White;
            this.labelNewsArchive.ForeColor = Color.Orange;
        }

        private void comboBoxNewsArcive_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBoxNewsArchiveDetail.Text = newsList[comboBoxNewsArcive.SelectedIndex].Detail;
        }
    }
}
