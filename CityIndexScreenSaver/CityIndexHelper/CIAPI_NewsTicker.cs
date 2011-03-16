using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIAPI;
using CIAPI.DTO;
using CityIndexHelper.ScreensaverStructures;
using CIAPI.Streaming;
using System.Threading;
using StreamingClient;

namespace CityIndexHelper
{
    public class NewsReceivedArgs : EventArgs
    {
        public NewsDetailDTO NewsDetail { get; private set; }
        public NewsReceivedArgs(NewsDetailDTO newsDetailDTO)
        {
            NewsDetail = newsDetailDTO;
        }
    }
    public class CIAPI_NewsTicker
    {
        public event EventHandler<NewsReceivedArgs> NewsReceived;

        protected void OnNewsReceived(NewsReceivedArgs e)
        {
            if (NewsReceived != null)
            {
                NewsReceived(this, e);
            }
        }

        private static readonly Uri RPC_URI = new Uri("https://ciapipreprod.cityindextest9.co.uk/tradingapi");
        private static readonly Uri STREAMING_URI = new Uri("https://pushpreprod.cityindextest9.co.uk/CITYINDEXSTREAMING");
        private const string USERNAME = "DM186764";
        private const string PASSWORD = "password";

        CIAPI.Rpc.Client ctx;
        IStreamingClient streamingClient;
        IStreamingListener<NewsDTO> newsListener;

        public void SubscribeToNewsHeadlineStream()
        {
            ctx = new CIAPI.Rpc.Client(RPC_URI);
            ctx.LogIn(USERNAME, PASSWORD);

            streamingClient = StreamingClientFactory.CreateStreamingClient(STREAMING_URI, USERNAME, ctx.SessionId);
            streamingClient.Connect();

            newsListener = streamingClient.BuildListener<NewsDTO>("NEWS.MOCKHEADLINES.UK");
            newsListener.Start();

            var gate = new ManualResetEvent(false);
            newsListener.MessageRecieved += (s, e) =>
            {
                newsReceived(e.Data.StoryId);
                gate.Set();
            };
            gate.WaitOne();
        }
        public void UnSubscribeNewsHeadLineStream()
        {
            newsListener.Stop();
            streamingClient.Disconnect();
            ctx.LogOut();
        }
        
        
        static List<int> storyIDsArchive = new List<int>();
        static Queue<string> storyIDsForDetails = new Queue<string>();

        private void newsReceived(int latestStoryID)
        {
            if (!storyIDsArchive.Contains(latestStoryID))
            {
                storyIDsArchive.Add(latestStoryID);
                lock (storyIDsForDetails)
                {
                    storyIDsForDetails.Enqueue(latestStoryID.ToString());
                }
                GetNewsDetails();
            }
        }


        public void GetNewsDetails()
        {
            GetNewsDetailResponseDTO newsDetail = new GetNewsDetailResponseDTO();

            var ctx = new CIAPI.Rpc.Client(RPC_URI);
            ctx.LogIn(USERNAME, PASSWORD);
            while (storyIDsForDetails.Count > 0)
            {
                newsDetail = ctx.GetNewsDetail(storyIDsForDetails.Dequeue());

                OnNewsReceived(new NewsReceivedArgs(newsDetail.NewsDetail));
            }

            ctx.LogOut();
        }
    }
}
