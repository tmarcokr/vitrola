using MPEGCast.Core;
using MPEGHeaderInfo.ICES;
using MPEGInfo;
using System;
using System.IO;

namespace PlayList
{
    public class MediaPlayer : IDisposable
    {
        public MediaPlayerStatus Status { get; private set; }

        private IceTcpClient IceCastTcpClient { get; set; }

        private StreamingPulse PlayerStreaming { get; set; }

        public MediaPlayer(IceTcpClient iceCastTcpClient)
        {
            Status = MediaPlayerStatus.Stoped;
            IceCastTcpClient = iceCastTcpClient;
        }

        public void Play(Stream songSource, Action nextMedia)
        {
            PreparePlayerStreaming(songSource, nextMedia);
            PlayerStreaming.Start();
            Status = MediaPlayerStatus.Playing;
        }

        public void Stop()
        {
            PlayerStreaming.Stop();
            PlayerStreaming.Dispose();
            PlayerStreaming = null;
            Status = MediaPlayerStatus.Stoped;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void PreparePlayerStreaming(Stream song, Action nextSong)
        {
            var streamSource = new MPEGStream(song);
            var streamReader = new MPEGStreamReader(streamSource);
            var mpegFrames = new MPEGFrames(streamReader);
            PlayerStreaming = new StreamingPulse(IceCastTcpClient, mpegFrames, nextSong);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                PlayerStreaming?.Dispose();
                PlayerStreaming = null;

                IceCastTcpClient?.Dispose();
                IceCastTcpClient = null;
            }
        }
    }
}
