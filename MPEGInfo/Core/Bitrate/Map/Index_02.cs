using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_02 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(2, Versions.Version_I, Layers.Layer_I, BitratesKbps._64),
                BitrateIndexValue.Of(2, Versions.Version_I, Layers.Layer_II, BitratesKbps._48),
                BitrateIndexValue.Of(2, Versions.Version_I, Layers.Layer_III, BitratesKbps._40),
                BitrateIndexValue.Of(2, Versions.Version_II, Layers.Layer_I, BitratesKbps._48),
                BitrateIndexValue.Of(2, Versions.Version_II, Layers.Layer_II, BitratesKbps._16),
                BitrateIndexValue.Of(2, Versions.Version_II, Layers.Layer_III, BitratesKbps._16),
                BitrateIndexValue.Of(2, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._48),
                BitrateIndexValue.Of(2, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._16),
                BitrateIndexValue.Of(2, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._16),
            };
        }
    }
}