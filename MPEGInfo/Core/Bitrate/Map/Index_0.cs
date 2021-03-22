using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_0 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(0, Versions.Version_I, Layers.Layer_I, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_I, Layers.Layer_II, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_I, Layers.Layer_III, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_II, Layers.Layer_I, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_II, Layers.Layer_II, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_II, Layers.Layer_III, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._Free),
                BitrateIndexValue.Of(0, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._Free)
            };
        }
    }
}