﻿using MPEGInfo.Core.Types;
using System.Collections.Generic;

namespace MPEGInfo.Core.Bitrate.Map
{
    public class Index_12 : IMapperIndex<BitrateIndexValue>
    {
        public List<BitrateIndexValue> GetIndexMap()
        {
            return new List<BitrateIndexValue>()
            {
                BitrateIndexValue.Of(12, Versions.Version_I, Layers.Layer_I, BitratesKbps._384),
                BitrateIndexValue.Of(12, Versions.Version_I, Layers.Layer_II, BitratesKbps._256),
                BitrateIndexValue.Of(12, Versions.Version_I, Layers.Layer_III, BitratesKbps._224),
                BitrateIndexValue.Of(12, Versions.Version_II, Layers.Layer_I, BitratesKbps._192),
                BitrateIndexValue.Of(12, Versions.Version_II, Layers.Layer_II, BitratesKbps._128),
                BitrateIndexValue.Of(12, Versions.Version_II, Layers.Layer_III, BitratesKbps._128),
                BitrateIndexValue.Of(12, Versions.Version_II_5, Layers.Layer_I, BitratesKbps._192),
                BitrateIndexValue.Of(12, Versions.Version_II_5, Layers.Layer_II, BitratesKbps._128),
                BitrateIndexValue.Of(12, Versions.Version_II_5, Layers.Layer_III, BitratesKbps._128),
            };
        }
    }
}