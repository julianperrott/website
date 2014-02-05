namespace JulianPerrottName.Cache
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Caching;

    /// <summary>
    /// HttpRuntime Cache
    /// </summary>
    public class HttpRuntimeCache : IApplicationCache
    {
        /// <summary>
        /// Gets the specified key from the cache.
        /// </summary>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <param name="cacheId">The key.</param>
        /// <param name="getItemCallback">The get item callback, this is called if the item is not in the cache.</param>
        /// <param name="secondsToCache">The item expiry in seconds.</param>
        /// <returns>An item</returns>
        public T Get<T>(string cacheId, Func<T> getItemCallback, int secondsToCache) where T : class
        {
            CachedItem cachedItem = HttpRuntime.Cache.Get(cacheId) as CachedItem;

            T item = null;
            if (cachedItem == null)
            {
                item = getItemCallback();

                cachedItem = new CachedItem() { Item = item, Key = cacheId, ExpiryTime = DateTime.UtcNow.AddSeconds(secondsToCache) };

                HttpRuntime.Cache.Insert(
                    cacheId,
                    cachedItem,
                    null,
                    cachedItem.ExpiryTime,
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    CacheItemPriority.Normal,
                    null);

                System.Diagnostics.Debug.WriteLine("HttpRuntimeCache: " + cacheId + " inserted into cache. Expires " + cachedItem.ExpiryTime.ToLongTimeString());
            }
            else
            {
                //// System.Diagnostics.Debug.WriteLine("HttpRuntimeCache: " + cacheId + " retrieved from cache. Expires " + cachedItem.ExpiryTime.ToLongTimeString());
                item = cachedItem.Item as T;
            }

            return item;
        }

        /// <summary>
        /// Deletes the specified cache item.
        /// </summary>
        /// <param name="cacheId">The cache id.</param>
        public void Delete(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }

        /// <summary>
        /// Clears this cache.
        /// </summary>
        public void Clear()
        {
            List<CachedItem> cachedItems = this.GetCachedItems();
            foreach (CachedItem item in cachedItems)
            {
                this.Delete(item.Key);
            }
        }

        /// <summary>
        /// Gets the cached items.
        /// </summary>
        /// <returns>A list of cached items</returns>
        public List<CachedItem> GetCachedItems()
        {
            List<CachedItem> items = new List<CachedItem>();
            var enumerator = HttpRuntime.Cache.GetEnumerator();
            bool hasItems = enumerator.MoveNext();

            while (hasItems)
            {
                DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
                object ob = dictionaryEntry.Value;
                if (ob.GetType() == typeof(CachedItem))
                {
                    items.Add((CachedItem)dictionaryEntry.Value);
                }

                hasItems = enumerator.MoveNext();
            }

            return items;
        }
    }
}