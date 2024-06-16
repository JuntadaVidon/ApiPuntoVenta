namespace M4Facturation.Application.Services.Implementations;
    public class CacheService(IMemoryCache cache, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        : BaseService(mapper, httpContextAccessor, cache), ICacheService
    {
        private static ConcurrentDictionary<string, bool> _cacheKeys = new();

        public OperationResponse<object?> GetCache(string key)
        {
            var data = _cache.Get(key);
            if (data == null)
            {
                NotFound<object>();
            }

            return Ok(data);
        }

        public OperationResponse<T> SetCache<T>(string key, T data)
        {
            _cache?.Set(key, data, DateTime.Now.AddHours(2));
            return Ok(data);
        }

        public OperationResponse<T> SetLongCache<T>(string key, T data)
        {
            _cache?.Set(key, data, DateTime.Now.AddDays(4));
            _cacheKeys.TryAdd(key, true);
            return Ok(data);
        }

        public OperationResponse<ICollection<string>> GetAllKeysCache()
        {
            return Ok(_cacheKeys.Keys);
        }

        public OperationResponse<bool> RemoveAllKeysCache()
        {
            foreach (var key in _cacheKeys)
            {
                var result = RemoveKeyCache(key.Key);
                if (!result.Data)
                {
                    return BadRequest<bool>("Error removing key: " + key.Key);
                }
            }

            _cacheKeys.Clear();
            return Ok(_cacheKeys.IsEmpty);
        }

        public OperationResponse<bool> RemoveKeyCache(string key)
        {
            var data = GetCache(key);
            if (data.Data == null)
            {
                return NotFound<bool>();
            }

            _cache?.Remove(key);
            _cacheKeys.TryRemove(key, out _);
            return Ok(true);
        }

        public OperationResponse<string> GetUserCache()
        {
            //TODO: Sacar el dato que necesitamos de la token modificar User por la propiedad de la token que vamos a usar.
            var user = _httpContextAccessor?.HttpContext?.User;
            var claimValue = user?.Claims.FirstOrDefault(c => c.Type == "User")?.Value;
            if (claimValue == null)
            {
                return NotFound<string>();
            }

            return Ok(claimValue);
        }
    }