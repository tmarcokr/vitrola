using System;
using System.IO;
using System.Threading;

namespace MPEGInfo
{
    public class MPEGStream : IDisposable
    {
        private Semaphore MpegStreamSemaphore { get; set; }

        private Stream MpegStream { get; set; }

        public MPEGStream(Stream mpegStream)
        {
            MpegStream = mpegStream ?? throw new ArgumentNullException(nameof(mpegStream));
            MpegStreamSemaphore = new Semaphore(1, 1, "MPEGStream");
        }

        public byte[] Read(long streamPosition, int readLength)
        {
            Lock();
            SetStreamPosition(streamPosition);
            var value = new byte[readLength];
            MpegStream.Read(value, 0, value.Length);
            Release();
            return value;
        }

        public long GetLength()
        {
            return MpegStream.Length;
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
                MpegStream.Close();
                MpegStream.Dispose();
                MpegStream = null;
            }
        }

        private void SetStreamPosition(long positon)
        {
            MpegStream.Position = positon;
        }

        private bool Lock()
        {
            return MpegStreamSemaphore.WaitOne();
        }

        private int Release()
        {
            return MpegStreamSemaphore.Release();
        }
    }
}