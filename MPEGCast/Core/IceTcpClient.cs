using System;
using System.Text;

namespace MPEGCast.Core
{
    public class IceTcpClient : IDisposable
    {
        private IceNetworkHandler IceNetworkHandler { get; set; }

        private string StreamingName { get; set; }

        private bool IsOpen { get; set; } = false;

        public IceTcpClient(IceNetworkHandler iceNetworkHandler, string streamingName)
        {
            IceNetworkHandler = iceNetworkHandler;
            StreamingName = streamingName;
        }

        public void Open()
        {
            if (IsOpen)
            {
                return;
            }

            IceNetworkHandler.Open();
            WriteHeader();
            IsOpen = true;
        }

        public void Write(byte[] data)
        {
            IceNetworkHandler.Write(data);
        }

        public void Close()
        {
            if (!IsOpen)
            {
                return;
            }

            IceNetworkHandler.Dispose();
            IsOpen = false;
        }

        private void WriteHeader()
        {
            var header = GetHeader();
            IceNetworkHandler.Write(header);
        }

        private byte[] GetHeader()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"PUT /{StreamingName} HTTP/1.1");
            builder.AppendLine("Host: localhost:8000");
            builder.AppendLine($"Content-Type: audio/mpeg");
            builder.AppendLine($"Authorization: Basic c291cmNlOmhhY2ttZQ==");
            builder.AppendLine($"ice-public: 1");
            builder.AppendLine($"ice-name: thiko");
            builder.AppendLine($"ice-url: localhost:8000/thiko");
            builder.AppendLine($"ice-genre: Rock");
            builder.AppendLine($"ice-description: Radio de pruebas Thiko");
            builder.AppendLine("Connection: keep-alive");
            builder.AppendLine();

            var iceCastHeader = builder.ToString();
            return Encoding.ASCII.GetBytes(iceCastHeader);

            #region "NotUsed Headers"
            //builder.AppendLine($"Content-Length: {totalBytes}");
            //builder.AppendLine($"ice-bitrate: 128");
            //builder.AppendLine($"ice-samplerate: 44100");
            //builder.AppendLine($"ice-audio-info: ice-samplerate=44100;ice-bitrate=128;ice-channels=2");
            #endregion
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
                Close();
            }
        }
    }
}