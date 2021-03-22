using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.SamplingRate.Map
{
    public class Index_03 : IMapperIndex<SamplingRateIndexValue>
    {
        public List<SamplingRateIndexValue> GetIndexMap()
        {
            return new List<SamplingRateIndexValue>()
            {
                SamplingRateIndexValue.Of(3, Versions.Version_I, SamplingsRateHz._Reserv),
                SamplingRateIndexValue.Of(3, Versions.Version_II, SamplingsRateHz._Reserv),
                SamplingRateIndexValue.Of(3, Versions.Version_II_5, SamplingsRateHz._Reserv)
            };
        }
    }
}