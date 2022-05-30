using Microsoft.Extensions.Caching.Memory;

namespace SSO.Demo.Web1.Utils
{
    /// <summary>
    /// 缓存帮助类-真正项目这里用redis
    /// </summary>
    public class Cachelper
    {
        //内存缓存
        private IMemoryCache _meoryCache;
        public Cachelper(IMemoryCache memoryCache)
        {
            _meoryCache = memoryCache;
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T value, TimeSpan? expiry = null)
        {
            if (expiry == null)
            {
                _meoryCache.Set<T>(key, value);
            }
            else
            {
                _meoryCache.Set<T>(key, value, (TimeSpan)expiry);
            }
            return true;
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T StringGet<T>(string key)
        {
            T result = _meoryCache.Get<T>(key);
            return result;
        }
        public void DeleteKey(string key)
        {
            _meoryCache.Remove(key);
        }
    }
}
