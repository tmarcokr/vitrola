using System.Collections.Generic;

namespace MPEGInfo.Core
{
    public interface IMapperIndex<TMapValue>
        where TMapValue : class
    {
        List<TMapValue> GetIndexMap();
    }
}