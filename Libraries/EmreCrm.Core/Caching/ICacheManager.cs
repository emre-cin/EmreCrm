using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmreCrm.Core.Caching
{
    public interface ICacheManager
    {
        void Set<T>(string cacheKey, T model);
        Task<bool> Clear();
        T Get<T>(string cacheKey);
        bool Contains(object key);
        void Remove(object key);
    }
}
