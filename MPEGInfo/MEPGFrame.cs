using MPEGInfo.Core.Types;
using System;

namespace MPEGInfo
{
    public class MEPGFrame
    {
        private const int LayerIFrameSize = 384;

        private const int LayerIIAndIIIFrameSize = 1152;

        public BitratesKbps BitRate { get; private set; }

        public Layers Layer { get; private set; }

        public Versions Version { get; private set; }

        public SamplingsRateHz SamplingRateHz { get; private set; }

        public long FrameBeginPosition { get; private set; }

        public bool IsPadding { get; private set; }

        private MEPGFrame()
        {
        }

        public int GetSamplesPerFrame()
        {
            switch (Layer)
            {
                case Layers.Layer_III:
                case Layers.Layer_II:
                    return LayerIIAndIIIFrameSize;
                case Layers.Layer_I:
                    return LayerIFrameSize;
                default:
                    throw new Exception($"The Layer: {Layer} does not have a defined frame size.");
            }
        }

        public int GetPaddingSizeInBytes()
        {
            return IsPadding ? 1 : 0;
        }

        public decimal GetFrameLengthInBytes()
        {
            switch (Layer)
            {
                case Layers.Layer_III:
                case Layers.Layer_II:
                    var frameLengthInBits = 144 * (decimal)BitRate / (decimal)SamplingRateHz + GetPaddingSizeInBytes();
                    var frameLengthInBytes = Math.Floor(frameLengthInBits);
                    return frameLengthInBytes;
                case Layers.Layer_I:
                    return (12 * (decimal)BitRate / (decimal)SamplingRateHz + GetPaddingSizeInBytes()) * 4;
                default:
                    throw new Exception($"The Layer: {Layer} does not have a defined frame length algorithm");
            }
        }

        public static MEPGFrame Of(BitratesKbps bitRate, Layers layers, Versions versions, SamplingsRateHz samplingsRateHz, bool isPadding, long frameBeginPosition)
        {
            if (bitRate == BitratesKbps._Bad || bitRate == BitratesKbps._Free)
            {
                throw new ArgumentException($"Invalid MPEG head; bitrate is out of Range, current bitrate value: {bitRate}.", nameof(bitRate));
            }

            if (layers == Layers.Reserverd)
            {
                throw new ArgumentException($"Invalid MPEG head; MPEG layer is out of range, current MPEG layer: {layers}.", nameof(layers));
            }

            if (versions == Versions.Reserved)
            {
                throw new ArgumentException($"Invalid MPEG head; MPEG version is out of range, current MPEG Version: {versions}.", nameof(bitRate));
            }

            if (samplingsRateHz == SamplingsRateHz._Reserv)
            {
                throw new ArgumentException($"Invalid MPEG head; MPEG sampling is out of range, current MPEG sampling: {samplingsRateHz}.", nameof(samplingsRateHz));
            }

            if (frameBeginPosition < 0)
            {
                throw new IndexOutOfRangeException($"The parameter '{nameof(frameBeginPosition)}' should be grater than zero.");
            }

            return new MEPGFrame()
            {
                BitRate = bitRate,
                Layer = layers,
                Version = versions,
                SamplingRateHz = samplingsRateHz,
                IsPadding = isPadding,
                FrameBeginPosition = frameBeginPosition
            };
        }
    }
}