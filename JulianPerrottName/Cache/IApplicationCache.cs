namespace JulianPerrottName.Cache
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Application Scope Cache Interface
    /// </summary>
    public interface IApplicationCache
    {
        /// <summary>
        /// Gets the specified key from the cache.
        /// </summary>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <param name="cacheId">The key.</param>
        /// <param name="getItemCallback">The get item callback, this is called if the item is not in the cache.</param>
        /// <param name="secondsToCache">The item expiry in seconds.</param>
        /// <returns>An item</returns>
        T Get<T>(string cacheId, Func<T> getItemCallback, int secondsToCache) where T : class;

        /// <summary>
        /// Deletes the specified cache id.
        /// </summary>
        /// <param name="cacheId">The cache id.</param>
        void Delete(string cacheId);

        /// <summary>
        /// Gets the cached items.
        /// </summary>
        /// <returns>A list of cached items</returns>
        List<CachedItem> GetCachedItems();

        /// <summary>
        /// Clears this cache.
        /// </summary>
        void Clear();
    }
}