using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIAPI;
using CIAPI.DTO;
using CIAPI.Streaming;
using System.Threading;
using StreamingClient;

namespace CityIndexHelper
{
    public class PriceReceivedArgs : EventArgs
    {
        public PriceDTO PriceTick { get; private set; }
        public PriceReceivedArgs(PriceDTO priceDTO)
        {
            PriceTick = priceDTO;
        }
    }
    public class CIAPI_Prices
    {
        public event EventHandler<PriceReceivedArgs> PriceReceived;

        protected void OnPriceReceived(PriceReceivedArgs e)
        {
            if (PriceReceived != null)
            {
                PriceReceived(this, e);
            }
        }

        //List<IStreamingListener> priceListnerList = new List<IStreamingListener>();
        IStreamingListener<PriceDTO> priceListner;
        public void SubscribeToPrice(object marketId)
        {
            if (!CIAPI_Global.IsConnected)
                CIAPI_Global.ConnectCIAPI();

            priceListner = CIAPI_Global.StreamingClient.BuildPriceListener("PRICES.PRICE." + marketId);//marketIDs[i]);
            priceListner.Start();

            var gate = new ManualResetEvent(false);
            priceListner.MessageReceived += (sender, priceArg) =>
            {
                OnPriceReceived(new PriceReceivedArgs(priceArg.Data));
                gate.Set();
            };
            gate.WaitOne();
        }
        //public void SubscribeToPrice(object marketId)
        //{
        //    if (!CIAPI_Global.IsConnected)
        //        CIAPI_Global.ConnectCIAPI();

        //    List<string> marketIDs = (List<string>)marketIdsList;

        //    for (int i = 0; i < marketIDs.Count; i++)
        //    {
        //    var priceStreamListner = CIAPI_Global.StreamingClient.BuildPriceListener("PRICES.PRICE." + marketId);//marketIDs[i]);
        //        priceStreamListner.Start();

        //        priceListnerList.Add(priceStreamListner);

        //        var gate = new ManualResetEvent(false);
        //        priceStreamListner.MessageReceived += (sender, priceArg) =>
        //        {
        //            OnPriceReceived(new PriceReceivedArgs(priceArg.Data));
        //            gate.Set();
        //        };
        //        gate.WaitOne();
        //    }
        //}

        public void UnSubscribePriceStream()
        {
            priceListner.Stop();
            CIAPI_Global.DisConnectCIAPI();
        }
    }
}
