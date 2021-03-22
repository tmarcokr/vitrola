using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.SamplingRate.Map
{
    public class Index_01 : IMapperIndex<SamplingRateIndexValue>
    {
        public List<SamplingRateIndexValue> GetIndexMap()
        {
            return new List<SamplingRateIndexValue>()
            {
                SamplingRateIndexValue.Of(1, Versions.Version_I, SamplingsRateHz._48000),
                SamplingRateIndexValue.Of(1, Versions.Version_II, SamplingsRateHz._24000),
                SamplingRateIndexValue.Of(1, Versions.Version_II_5, SamplingsRateHz._12000),
            };
        }
    }
}