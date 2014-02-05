namespace JulianPerrottName.Cache
{
    using System;

    /// <summary>
    /// Cached Item
    /// </summary>
    public class CachedItem
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public object Item { get; set; }

        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        /// <value>
        /// The expires.
        /// </value>
        public DateTime ExpiryTime { get; set; }
    }
}