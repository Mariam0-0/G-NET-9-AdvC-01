using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_9_AdvC_01
{
    internal class Cache<TKey,TValue>
    {
        //Q20: Complete Exercise - Create a generic Cache<TKey, TValue>with Add, Get, Remove, Contains, and expiration support.

        private readonly Dictionary<TKey, CacheItem> _cache = new Dictionary<TKey, CacheItem>();
        private readonly TimeSpan _defaultExpiration;
        
        private class CacheItem
        {
            public TValue Value { get; set; }
            public DateTime ExpirationTime { get; set; }

            public CacheItem(TValue value, TimeSpan expiration)
            {
                Value = value;
                ExpirationTime = DateTime.Now.Add(expiration);
            }

            public bool IsExpired()
            {
                return DateTime.Now >= ExpirationTime;
            }
        }

        public Cache(TimeSpan defaultExpiration)
        {
            _defaultExpiration = defaultExpiration;
        }
        public void Add(TKey key, TValue value, TimeSpan? expiration = null)
        {
            var expiry = expiration ?? _defaultExpiration;
            _cache[key] = new CacheItem(value,expiry);
        }
       
        public TValue Get(TKey key)
        {
            if (_cache.TryGetValue(key, out var item) )
            {
                if (!item.IsExpired())
                    return item.Value;

                _cache.Remove(key);
            }
            return default(TValue);
        }

        public bool Remove(TKey key)
        {
            return _cache.Remove(key);
        }

        public bool Contains(TKey key)
        {
            if (_cache.TryGetValue(key, out var item))
            {
                if(!item.IsExpired())  return true;

                _cache.Remove(key);
            }
            return false;
        }

        public void Clear()
        {
            _cache.Clear();
        }
    }
}
