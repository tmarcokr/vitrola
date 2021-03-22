using MPEGInfo.Core.Bitrate;
using MPEGInfo.Core.SamplingRate;
using MPEGInfo.Core.Types;
using System;

namespace MPEGInfo.Extension
{
    public static class MPEGFrameExtension
    {
        private const int HeaderLength = 4;

        private static BitrateIndex BitrateIndex { get; set; }

        private static SamplingRateIndex SamplingRateIndex { get; set; }

        public static void Initialize(BitrateIndex bitrateIndex, SamplingRateIndex samplingRateIndex)
        {
            BitrateIndex = bitrateIndex;
            SamplingRateIndex = samplingRateIndex;
        }

        public static MEPGFrame GetFrame(this MPEGStream source, long frameBeginPosition)
        {
            var frameHeader = source.Read(frameBeginPosition, HeaderLength);
            if (frameHeader == null)
            {
                throw new ArgumentNullException(nameof(frameHeader));
            }

            var frameSyncIsSet = (frameHeader[0] == 0xFF) && ((frameHeader[1] & 0xE0) == 0xE0);
            if (!frameSyncIsSet)
            {
                throw new ArgumentException("The frame sync should be set.", nameof(frameHeader));
            }

            try
            {
                return MEPGFrame.Of(GetBitrate(frameHeader), GetLayer(frameHeader),
                                      GetVersion(frameHeader), GetSamplingRate(frameHeader),
                                      GetPadding(frameHeader), frameBeginPosition);
            }
            catch (Exception ex)
            {
                throw new Exception("Imposible read frameHeader!", ex);
            }
        }

        private static Versions GetVersion(byte[] frameHeader)
        {
            return (Versions)((frameHeader[1] & 0x18) >> 3);
        }

        private static Layers GetLayer(byte[] frameHeader)
        {
            return (Layers)((frameHeader[1] & 0x06) >> 1);
        }

        private static int GetBitRateIndex(byte[] frameHeader)
        {
            return (frameHeader[2] & 0xF0) >> 4;
        }

        private static int GetSamplingRateIndex(byte[] frameHeader)
        {
            return (frameHeader[2] & 0x0C) >> 2;
        }

        private static bool GetPadding(byte[] frameHeader)
        {
            return (frameHeader[2] & 0x02) == 0x02;
        }

        private static BitratesKbps GetBitrate(byte[] frameHeader)
        {
            if (BitrateIndex == null)
            {
                throw new ArgumentNullException(nameof(BitrateIndex), "The MPEGFrameHeaderExtension is not initialized. Tip: Before use call the Initialize method");
            }
            return BitrateIndex.GetBitrate(GetBitRateIndex(frameHeader), GetVersion(frameHeader), GetLayer(frameHeader));
        }

        private static SamplingsRateHz GetSamplingRate(byte[] frameHeader)
        {
            if (SamplingRateIndex == null)
            {
                throw new ArgumentNullException(nameof(SamplingRateIndex), "The MPEGFrameHeaderExtension is not initialized. Tip: Before use call the Initialize method");
            }
            return SamplingRateIndex.GetSamplingRate(GetSamplingRateIndex(frameHeader), GetVersion(frameHeader));
        }
    }
}
