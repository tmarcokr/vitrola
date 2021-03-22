using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_03 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(4, Versions.Version_I, Layers.Layer_I, BitratesKbps._128),
                BitrateIndexValue.Of(4, Versions.Version_I, Layers.Layer_II, BitratesKbps._64),
                BitrateIndexValue.Of(4, Versions.Version_I, Layers.Layer_III, BitratesKbps._56),
                BitrateIndexValue.Of(4, Versions.Version_II, Layers.Layer_I, BitratesKbps._64),
                BitrateIndexValue.Of(4, Versions.Version_II, Layers.Layer_II, BitratesKbps._32),
                BitrateIndexValue.Of(4, Versions.Version_II, Layers.Layer_III, BitratesKbps._32),
                BitrateIndexValue.Of(4, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._64),
                BitrateIndexValue.Of(4, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._32),
                BitrateIndexValue.Of(4, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._32),
            };
        }
    }
}