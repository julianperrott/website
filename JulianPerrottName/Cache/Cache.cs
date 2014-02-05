namespace JulianPerrottName.Cache
{
    using System;

    public class Cache : HttpRuntimeCache
    {
        /// <summary>
        /// Ten minutes in seconds
        /// </summary>
        protected const int CacheForTenMinutes = 600;

        /// <summary>
        /// One minute in seconds
        /// </summary>
        protected const int CacheForOneMinute = 60;

        /// <summary>
        /// Ten minutes in seconds
        /// </summary>
        protected const int CacheForOneHour = 3600;

        /// <summary>
        /// Gets the specified key from the cache.
        /// </summary>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="getItemCallback">The get item callback, this is called if the item is not in the cache.</param>
        /// <param name="secondsToCache">The item expiry in seconds.</param>
        /// <returns>An item</returns>
        protected T GetUsingCacheKey<T>(string key, Func<T> getItemCallback, int secondsToCache) where T : class
        {
            T value = this.Get<T>(this.GetCacheKey(key), getItemCallback, secondsToCache);
            return value;
        }

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A string</returns>
        protected string GetCacheKey(string key)
        {
            return this.GetType().Name + "_" + key;
        }

        /// <summary>
        /// Delete the cache key.
        /// </summary>
        /// <param name="cacheId">The key.</param>
        protected void DeleteUsingCacheKey(string cacheId)
        {
            this.Delete(this.GetCacheKey(cacheId));
        }
    }
}