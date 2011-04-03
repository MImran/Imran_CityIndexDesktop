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
    public class News
    {
        public string Headline { get; set; }
        public string Detail { get; set; }
    }
    public class CIAPI_Global
    {
        private static readonly Uri RPC_URI = new Uri("https://ciapipreprod.cityindextest9.co.uk/tradingapi");
        private static readonly Uri STREAMING_URI = new Uri("https://pushpreprod.cityindextest9.co.uk/CITYINDEXSTREAMING");
        private const string USERNAME = "DM889651";
        private const string PASSWORD = "password";

        public static CIAPI.Rpc.Client CIAPI_Client;
        public static CIAPI.Streaming.IStreamingClient StreamingClient;

        public static bool IsConnected = false;

        public static void ConnectCIAPI()
        {
            CIAPI_Client = new CIAPI.Rpc.Client(RPC_URI);
            CIAPI_Client.LogIn(USERNAME, PASSWORD);

            StreamingClient = StreamingClientFactory.CreateStreamingClient(STREAMING_URI, USERNAME, CIAPI_Client.SessionId);
            StreamingClient.Connect();

            IsConnected = true;
        }
        public static void DisConnectCIAPI()
        {
            StreamingClient.Disconnect();
            CIAPI_Client.LogOut();
            CIAPI_Client.Dispose();

            IsConnected = false;
        }
    }
}
