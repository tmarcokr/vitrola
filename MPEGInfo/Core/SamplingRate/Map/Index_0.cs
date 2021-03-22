using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.SamplingRate.Map
{
    public class Index_0 : IMapperIndex<SamplingRateIndexValue>
    {
        public List<SamplingRateIndexValue> GetIndexMap()
        {
            return new List<SamplingRateIndexValue>()
            {
                SamplingRateIndexValue.Of(0, Versions.Version_I, SamplingsRateHz._44100),
                SamplingRateIndexValue.Of(0, Versions.Version_II, SamplingsRateHz._22050),
                SamplingRateIndexValue.Of(0, Versions.Version_II_5, SamplingsRateHz._11025)
            };
        }
    }
}