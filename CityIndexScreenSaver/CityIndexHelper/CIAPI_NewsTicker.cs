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

        IStreamingListener<NewsDTO> newsListener;

        public void SubscribeToNewsHeadlineStream()
        {
            if (!CIAPI_Global.IsConnected)
                CIAPI_Global.ConnectCIAPI();
            newsListener = CIAPI_Global.StreamingClient.BuildNewsHeadlinesListener("NEWS.MOCKHEADLINES.UK");
            newsListener.Start();

            var gate = new ManualResetEvent(false);
            newsListener.MessageReceived += (s, e) =>
            {
                newsReceived(e.Data.StoryId);
                gate.Set();
            };
            gate.WaitOne();
        }
        public void UnSubscribeNewsHeadLineStream()
        {
            newsListener.Stop();
            CIAPI_Global.DisConnectCIAPI();
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

            while (storyIDsForDetails.Count > 0)
            {
                newsDetail = CIAPI_Global.CIAPI_Client.GetNewsDetail(storyIDsForDetails.Dequeue());

                OnNewsReceived(new NewsReceivedArgs(newsDetail.NewsDetail));
            }
        }
    }
}
