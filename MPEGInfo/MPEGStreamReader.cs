using MPEGInfo.Extension;
using System;

namespace MPEGInfo
{
    public class MPEGStreamReader : IDisposable
    {
        private MPEGStream MpegStream { get; set; }

        private long BeginMpegPosition { get; set; }

        private long EndMpegPosition { get; set; }

        public MEPGFrame Current { get; set; }

        public MPEGStreamReader(MPEGStream source)
        {
            MpegStream = source ?? throw new ArgumentNullException(nameof(source));
            InitilizeMpegStream();
        }

        public void ResetMpegStream()
        {
            Current = null;
        }

        public void SetCurrentMpegFrame(long frameHeaderPosition)
        {
            Current = MpegStream.GetFrame(frameHeaderPosition);
        }

        public byte[] GetFrameBytes(MEPGFrame value)
        {
            var frameBytes = MpegStream.Read(value.FrameBeginPosition, (int)value.GetFrameLengthInBytes());
            return frameBytes;
        }

        public (bool eof, long nextPosition) CanMoveNext()
        {
            var nextPosition = GetNextFramePosition();
            var eof = IsEof(nextPosition);
            return (eof, nextPosition);
        }

        private void InitilizeMpegStream()
        {
            var (hasId3v2Tag, endId3V2Position) = MpegStream.HasId3v2Tag();
            var (hasId3v1Tag, endId3v1Position) = MpegStream.HasId3v1Tag();

            BeginMpegPosition = 0;
            if (hasId3v2Tag)
            {
                BeginMpegPosition = endId3V2Position;
            }

            EndMpegPosition = MpegStream.GetLength();
            if (hasId3v1Tag)
            {
                EndMpegPosition = endId3v1Position;
            }
        }

        private bool IsEof(long position)
        {
            return (position + 1) > (EndMpegPosition);
        }

        private long GetNextFramePosition()
        {
            var position = BeginMpegPosition;
            if (Current != null)
            {
                var nextFramePosition = Current.FrameBeginPosition + Current.GetFrameLengthInBytes();
                position = (long)nextFramePosition;
            }

            return position;
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
                MpegStream.Dispose();
                MpegStream = null;
            }
        }
    }
}