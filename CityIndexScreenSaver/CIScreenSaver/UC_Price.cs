using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIAPI.DTO;
using CityIndexHelper;
using System.Threading;

namespace CIScreenSaver
{
    public partial class UC_Price : UserControl
    {
        public UC_Price()
        {
            InitializeComponent();
        }

        List<double> chartList = new List<double>();

        private void updateUI(PriceDTO priceDto)
        {
            this.labelBid.Text = priceDto.Bid.ToString();
            this.labelCurrentPrice.Text = priceDto.Price.ToString();
            this.labelMarketHigh.Text = priceDto.High.ToString();
            this.labelMarketLow.Text = priceDto.Low.ToString();
            this.labelOffer.Text = priceDto.Offer.ToString();
            this.labelMarketChange.Text = priceDto.Direction == 0 ? "-" : "+" + "  " + priceDto.Change.ToString();

            if (priceDto.Direction == 0)
                this.labelMarketChange.ForeColor = Color.Crimson;
            else
                this.labelMarketChange.ForeColor = Color.YellowGreen;

            chartList.Add(33);
            chartList.Add(83);
            chartList.Add(51);

            this.chartTick.Series[0].Points.Add(33);
            this.chartTick.Series[0].Points.Add(53);
            this.chartTick.Series[0].Points.Add(13);
        }
        void priceTicker_PriceReceived(object sender, PriceReceivedArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    priceTicker_PriceReceived(sender, e);
                });

                return;
            }

            updateUI(e.PriceTick);
        }


        CIAPI_Prices priceTicker;
        Thread priceTickerThread;
        public void StartControl(string MarketID)
        {
            priceTicker = new CIAPI_Prices();
            priceTicker.PriceReceived += new EventHandler<PriceReceivedArgs>(priceTicker_PriceReceived);
            ParameterizedThreadStart pricesParameterThreadStart = new ParameterizedThreadStart(priceTicker.SubscribeToPrice);
            priceTickerThread = new Thread(pricesParameterThreadStart);
            priceTickerThread.Start((object)MarketID);
        }
        public void StopControl()
        {
            priceTicker.UnSubscribePriceStream();
            priceTickerThread.Abort();
        }
    }
}
