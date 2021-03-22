using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.SamplingRate.Map
{
    public class Index_02 : IMapperIndex<SamplingRateIndexValue>
    {
        public List<SamplingRateIndexValue> GetIndexMap()
        {
            return new List<SamplingRateIndexValue>()
            {
                SamplingRateIndexValue.Of(2, Versions.Version_I, SamplingsRateHz._32000),
                SamplingRateIndexValue.Of(2, Versions.Version_II, SamplingsRateHz._16000),
                SamplingRateIndexValue.Of(2, Versions.Version_II_5, SamplingsRateHz._8000),
            };
        }
    }
}