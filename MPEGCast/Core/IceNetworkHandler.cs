using System;
using System.Net.Sockets;

namespace MPEGCast.Core
{
    public class IceNetworkHandler : IDisposable
    {
        private const int SendTimeout = 0;

        private string Server { get; set; }

        private int Port { get; set; }

        private NetworkStream DataStream
        {
            get
            {
                return TcpClient.GetStream();
            }
        }

        private TcpClient TcpClient { get; set; }

        public IceNetworkHandler(string server, int port)
        {
            Server = server;
            Port = port;
        }

        public void Open()
        {
            TcpClient = new TcpClient(Server, Port) { SendTimeout = SendTimeout };
        }

        public void Write(byte[] data)
        {
            DataStream.WriteAsync(data).GetAwaiter().GetResult();
            DataStream.FlushAsync().GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                TcpClient.Close();
                TcpClient.Dispose();
                TcpClient = null;
            }
        }
    }
}