using MPEGInfo.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MPEGInfo.Core.Bitrate
{
    public class BitrateIndex
    {
        private IEnumerable<BitrateIndexValue> BitrateIndexes { get; set; }

        public BitrateIndex(IEnumerable<IMapperIndex<BitrateIndexValue>> bitrateIndexMappers)
        {
            if (bitrateIndexMappers == null)
            {
                throw new ArgumentNullException(nameof(bitrateIndexMappers));
            }

            BitrateIndexes = bitrateIndexMappers
                                .SelectMany(s => s.GetIndexMap());
        }

        public BitratesKbps GetBitrate(int bitrateIndex, Versions version, Layers layer)
        {
            try
            {
                return BitrateIndexes
                    .Single(s => s.Index == bitrateIndex &&
                                 s.Version == version &&
                                 s.Layer == layer)
                    .Bitrate;
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot get the birateKbps value; Index values are out of range. Index: {bitrateIndex}; version: {version}; layer: {layer}", ex);
            }
        }
    }
}