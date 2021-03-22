using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_10 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(10, Versions.Version_I, Layers.Layer_I, BitratesKbps._320),
                BitrateIndexValue.Of(10, Versions.Version_I, Layers.Layer_II, BitratesKbps._192),
                BitrateIndexValue.Of(10, Versions.Version_I, Layers.Layer_III, BitratesKbps._160),
                BitrateIndexValue.Of(10, Versions.Version_II, Layers.Layer_I, BitratesKbps._160),
                BitrateIndexValue.Of(10, Versions.Version_II, Layers.Layer_II, BitratesKbps._96),
                BitrateIndexValue.Of(10, Versions.Version_II, Layers.Layer_III, BitratesKbps._96),
                BitrateIndexValue.Of(10, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._160),
                BitrateIndexValue.Of(10, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._96),
                BitrateIndexValue.Of(10, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._96),
            };
        }
    }
}