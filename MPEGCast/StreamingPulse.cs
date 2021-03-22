using MPEGCast.Core;
using MPEGInfo;
using System;
using System.Timers;

namespace MPEGHeaderInfo.ICES
{
    public class StreamingPulse : IDisposable
    {
        private const int OneMileSecond = 1000;

        private bool BitRateSetFlag { get; set; }

        private Timer BitRateTimer { get; set; }

        private IceTcpClient TcpClient { get; set; }

        private MPEGFrames FramesInfo { get; set; }

        private Action EoFAction { get; set; }

        public StreamingPulse(IceTcpClient iceCastTcpClient, MPEGFrames framesInfo, Action eofAction)
        {
            TcpClient = iceCastTcpClient;
            FramesInfo = framesInfo;
            EoFAction = eofAction;
            ConfigureBitrateTimer();
        }

        public StreamingPulse(IceTcpClient iceCastTcpClient, MPEGFrames framesInfo)
        {
            TcpClient = iceCastTcpClient;
            FramesInfo = framesInfo;
            ConfigureBitrateTimer();
        }

        public void Start()
        {
            TcpClient.Open();
            BitRateTimer.Enabled = true;
        }

        public void Stop()
        {
            BitRateTimer.Enabled = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Pulse(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!FramesInfo.MoveNext())
                {
                    EoFAction?.Invoke();
                    return;
                }

                var frameInfo = FramesInfo.Current;
                var frameBytes = FramesInfo.GetFrameBytes(frameInfo);

                SetBitRate(frameInfo);
                TcpClient.Write(frameBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private void SetBitRate(MEPGFrame frameInfo)
        {
            if (BitRateSetFlag) return;

            var bitRateInBytes = ((int)frameInfo.BitRate / 8);                          //CALCULATE THE BITRATE IN BYTES.
            var samplesPerSecond = bitRateInBytes / frameInfo.GetFrameLengthInBytes();  //HOW MANY BYTES WE SHOULD SEND PER SECOND
            var bitRate = (int)(OneMileSecond / samplesPerSecond);                      //HOW MANY BYTES WE SHOULD SEND IN MS TO ACHIVE THE BYTES PER SECOND RATE
            BitRateTimer.Interval = bitRate;
            BitRateSetFlag = true;
        }

        private void ConfigureBitrateTimer()
        {
            BitRateTimer = new Timer()
            {
                AutoReset = true,
                Enabled = false
            };

            BitRateTimer.Elapsed += Pulse;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                FramesInfo.Dispose();
                FramesInfo = null;
            }
        }
    }
}