using MPEGInfo.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MPEGInfo.Core.SamplingRate
{
    public class SamplingRateIndex
    {
        private IEnumerable<SamplingRateIndexValue> SamplingRateIndexes { get; set; }

        public SamplingRateIndex(IEnumerable<IMapperIndex<SamplingRateIndexValue>> samplingRateIndexMapper)
        {
            if (samplingRateIndexMapper == null)
            {
                throw new ArgumentNullException(nameof(samplingRateIndexMapper));
            }

            SamplingRateIndexes = samplingRateIndexMapper
                                    .SelectMany(s => s.GetIndexMap());
        }

        public SamplingsRateHz GetSamplingRate(int samplingRateIndex, Versions version)
        {
            try
            {
                return SamplingRateIndexes
                    .Single(s => s.Index == samplingRateIndex && s.Version == version)
                    .SamplingsRateHz;
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot get the birateKbps value; Index values are out of range. Index: {samplingRateIndex}; version: {version}", ex);
            }
        }
    }
}
