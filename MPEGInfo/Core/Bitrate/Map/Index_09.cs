using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_09 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(9, Versions.Version_I, Layers.Layer_I, BitratesKbps._288),
                BitrateIndexValue.Of(9, Versions.Version_I, Layers.Layer_II, BitratesKbps._160),
                BitrateIndexValue.Of(9, Versions.Version_I, Layers.Layer_III, BitratesKbps._128),
                BitrateIndexValue.Of(9, Versions.Version_II, Layers.Layer_I, BitratesKbps._144),
                BitrateIndexValue.Of(9, Versions.Version_II, Layers.Layer_II, BitratesKbps._80),
                BitrateIndexValue.Of(9, Versions.Version_II, Layers.Layer_III, BitratesKbps._80),
                BitrateIndexValue.Of(9, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._144),
                BitrateIndexValue.Of(9, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._80),
                BitrateIndexValue.Of(9, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._80),
            };
        }
    }
}