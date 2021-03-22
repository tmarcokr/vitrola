using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_04 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(3, Versions.Version_I, Layers.Layer_I, BitratesKbps._96),
                BitrateIndexValue.Of(3, Versions.Version_I, Layers.Layer_II, BitratesKbps._56),
                BitrateIndexValue.Of(3, Versions.Version_I, Layers.Layer_III, BitratesKbps._48),
                BitrateIndexValue.Of(3, Versions.Version_II, Layers.Layer_I, BitratesKbps._56),
                BitrateIndexValue.Of(3, Versions.Version_II, Layers.Layer_II, BitratesKbps._24),
                BitrateIndexValue.Of(3, Versions.Version_II, Layers.Layer_III, BitratesKbps._24),
                BitrateIndexValue.Of(3, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._56),
                BitrateIndexValue.Of(3, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._24),
                BitrateIndexValue.Of(3, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._24),
            };
        }
    }
}