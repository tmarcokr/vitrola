using MPEGInfo.Core.Types;

namespace MPEGInfo.Core.Bitrate
{
    public class BitrateIndexValue
    {
        public int Index { get; private set; }

        public Versions Version { get; private set; }

        public Layers Layer { get; private set; }

        public BitratesKbps Bitrate { get; private set; }

        private BitrateIndexValue()
        {
        }

        public static BitrateIndexValue Of(int index, Versions version, Layers layer, BitratesKbps bitrate)
        {
            return new BitrateIndexValue()
            {
                Index = index,
                Version = version,
                Layer = layer,
                Bitrate = bitrate
            };
        }
    }
}