using MPEGInfo.Core.Types;

namespace MPEGInfo.Core.SamplingRate
{
    public class SamplingRateIndexValue
    {
        public int Index { get; private set; }

        public Versions Version { get; private set; }

        public SamplingsRateHz SamplingsRateHz { get; private set; }

        private SamplingRateIndexValue()
        {
        }

        public static SamplingRateIndexValue Of(int index, Versions version, SamplingsRateHz samplingsRateHz)
        {
            return new SamplingRateIndexValue()
            {
                Index = index,
                Version = version,
                SamplingsRateHz = samplingsRateHz
            };
        }
    }
}