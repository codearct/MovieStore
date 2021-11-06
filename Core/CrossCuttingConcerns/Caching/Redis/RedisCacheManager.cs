using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly RedisEndpoint _redisEndpoint;

        public RedisCacheManager()
        {
            _redisEndpoint = new RedisEndpoint("127.0.0.1", 6379);
        }

        public void Add(string key, object value, int duration)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.Set(key, value, TimeSpan.FromMinutes(duration));
            }
        }

         public T Get<T>(string key)
         {
             using (var redisClient = new RedisClient(_redisEndpoint))
             {
                 return redisClient.Get<T>(key);
             }                
         }

        public object Get(string key)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                return redisClient.Get(key);
            }
        }

        public bool IsAdd(string key)
        {
            var isAdded = false;
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                isAdded = redisClient.ContainsKey(key);
            }
            return isAdded;
        }

        public void Remove(string key)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.Remove(key);
            }
        }

        public void RemoveByPattern(string pattern)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.RemoveByPattern(pattern);
            }
        }
    }
}
