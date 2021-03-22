using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_06 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(6, Versions.Version_I, Layers.Layer_I, BitratesKbps._192),
                BitrateIndexValue.Of(6, Versions.Version_I, Layers.Layer_II, BitratesKbps._96),
                BitrateIndexValue.Of(6, Versions.Version_I, Layers.Layer_III, BitratesKbps._80),
                BitrateIndexValue.Of(6, Versions.Version_II, Layers.Layer_I, BitratesKbps._96),
                BitrateIndexValue.Of(6, Versions.Version_II, Layers.Layer_II, BitratesKbps._48),
                BitrateIndexValue.Of(6, Versions.Version_II, Layers.Layer_III, BitratesKbps._48),
                BitrateIndexValue.Of(6, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._96),
                BitrateIndexValue.Of(6, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._48),
                BitrateIndexValue.Of(6, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._48),
            };
        }
    }
}