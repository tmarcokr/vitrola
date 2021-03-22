using System;
using System.Collections;
using System.Collections.Generic;

namespace MPEGInfo
{
    public partial class MPEGFrames : IEnumerable<MEPGFrame>, IEnumerator<MEPGFrame>
    {
        public MEPGFrame Current => FramesReader.Current;

        object IEnumerator.Current => Current;

        private MPEGStreamReader FramesReader { get; set; }

        public MPEGFrames(MPEGStreamReader frames)
        {
            FramesReader = frames ?? throw new ArgumentNullException(nameof(frames));
        }

        public IEnumerator<MEPGFrame> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public byte[] GetFrameBytes(MEPGFrame value)
        {
            return FramesReader.GetFrameBytes(value);
        }

        public bool MoveNext()
        {
            var (eof, nextPosition) = FramesReader.CanMoveNext();
            if (eof)
            {
                Reset();
                return false;
            }

            FramesReader.SetCurrentMpegFrame(nextPosition);
            return true;
        }

        public void Reset()
        {
            FramesReader.ResetMpegStream();
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
                FramesReader.Dispose();
                FramesReader = null;
            }
        }
    }
}
