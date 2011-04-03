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

        //CIAPI_Prices priceTicker;
        List<string> marketIds = new List<string>();
        //Thread priceTickerThread;
        UC_Price priceUC;
        UC_Price priceUC2;

        private int screenNumber;
        private News news;
        BindingList<News> newsList;


        private void FormScreenSaver_Load(object sender, EventArgs e)
        {
            loadAndApplySettings();

            CIAPI_Global.ConnectCIAPI();
            do { Thread.Sleep(500); } while (!CIAPI_Global.IsConnected);

            newsTicker = new CIAPI_NewsTicker();
            newsTicker.NewsReceived += new EventHandler<NewsReceivedArgs>(newsTicker_NewsReceived);
            newsTickerThread = new Thread(new ThreadStart(newsTicker.SubscribeToNewsHeadlineStream));
            newsTickerThread.Start();

            //priceTicker = new CIAPI_Prices();
            //priceTicker.PriceReceived += new EventHandler<PriceReceivedArgs>(priceTicker_PriceReceived);
            //ParameterizedThreadStart pricesParameterThreadStart = new ParameterizedThreadStart(priceTicker.SubscribeToPrice);
            //priceTickerThread = new Thread(pricesParameterThreadStart);
            //marketIds.Add("99498");
            //marketIds.Add("99500");
            //priceTickerThread.Start((object)marketIds);

            priceUC = new UC_Price();
            priceUC.StartControl("99498");
            this.panel1.Controls.Add(priceUC);
        }

        private void loadAndApplySettings()
        {
            //this.Bounds = Screen.AllScreens[screenNumber].Bounds;
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
        void priceTicker_PriceReceived(object sender, PriceReceivedArgs e)
        {
            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke((MethodInvoker)delegate
            //    {
            //        priceTicker_PriceReceived(sender, e);
            //    });
                
            //    return;
            //}
            //if (e.PriceTick.MarketId == 99498)
            //    priceUC.SetUI(e.PriceTick);
            //else
            //    priceUC2.SetUI(e.PriceTick);
            //this.labelTest.Text = e.PriceTick.MarketId.ToString();
            //this.labelTest2.Text = e.PriceTick.Offer.ToString();
        }

        private void buttonResumeWindow_Click(object sender, EventArgs e)
        {
            newsTicker.UnSubscribeNewsHeadLineStream();
            newsTickerThread.Abort();
            this.Close();

            //priceTicker.UnSubscribePriceStream();
            //priceTickerThread.Abort();
            //this.Close();
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
