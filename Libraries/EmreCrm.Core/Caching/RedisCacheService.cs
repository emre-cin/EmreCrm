using EmreCrm.Core.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace EmreCrm.Core.Caching
{
    public class RedisCacheService : ICacheManager
    {
        private StackExchange.Redis.IDatabase _database;
        private RedisCacheOptions options;
        private AppSettings appSettings;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService()
        {
            appSettings = (AppSettings)ConfigurationManager.GetSection("AppSettings");
            options = new RedisCacheOptions
            {
                Configuration = "127.0.0.1:6379"
            };
            _connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379,allowAdmin=true");
        }

        public async Task<bool> Clear()
        {
            try
            {
                var endpoints = _connectionMultiplexer.GetEndPoints(true);
                foreach (var endpoint in endpoints)
                {
                    var server = _connectionMultiplexer.GetServer(endpoint);
                    server.FlushAllDatabases();
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Contains(object key)
        {
            return _database.KeyExists((RedisKey)key);

        }
        public T Get<T>(string cacheKey)
        {
            using (var redisCache = new RedisCache(options))
            {

                var valueString = redisCache.GetString(cacheKey);
                if (!string.IsNullOrEmpty(valueString))
                {
                    var valueObject = JsonConvert.DeserializeObject<T>(valueString);
                    return (T)valueObject;
                }

                return default(T);
            }

        }

        public void Remove(object key)
        {

            using (var redisCache = new RedisCache(options))
            {
                redisCache.Remove((string)key);
            }

        }
        public void Set<T>(string cacheKey, T model)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(90)
            };

            using (var redisCache = new RedisCache(options))
            {
                var valueString = JsonConvert.SerializeObject(model);
                redisCache.SetString(cacheKey, valueString);
            }

        }
    }
}
