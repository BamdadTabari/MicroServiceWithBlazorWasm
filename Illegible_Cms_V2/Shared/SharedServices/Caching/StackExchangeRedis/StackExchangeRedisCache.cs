using StackExchange.Redis;
using System.Text.Json;

namespace Illegible_Cms_V2.Shared.SharedServices.Caching.StackExchangeRedis;

public class StackExchangeRedisCache : ICache
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    private readonly string _prefix;

    public StackExchangeRedisCache(IConnectionMultiplexer multiplexer, string instancePrefix)
    {
        if (string.IsNullOrWhiteSpace(instancePrefix))
            throw new ArgumentException("Invalid instance prefix. Provide a valid string as prefix");

        _prefix = $"{instancePrefix.Trim().Replace(" ", "")}";
        _connectionMultiplexer = multiplexer;
    }

    public async Task<T> GetAsync<T>(string key, bool hasAbsoluteKey = false)
    {
        var finalKey = hasAbsoluteKey ? key : $"{_prefix}-{key}";
        var value = await _connectionMultiplexer.GetDatabase().StringGetAsync(finalKey);

        if (value.IsNull)
            return default;

        var result = JsonSerializer.Deserialize<T>(value);

        if (result != null)
            return result;

        throw new Exception("Null Reference Exception Occurred");
    }

    public async Task<bool> SetAsync<T>(string key, T value)
    {
        var redisValue = JsonSerializer.Serialize(value);
        return await _connectionMultiplexer.GetDatabase().StringSetAsync($"{_prefix}-{key}", redisValue);
    }

    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan ttl)
    {
        var redisValue = JsonSerializer.Serialize(value);
        return await _connectionMultiplexer.GetDatabase().StringSetAsync($"{_prefix}-{key}", redisValue, ttl);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        return await _connectionMultiplexer.GetDatabase().KeyDeleteAsync($"{_prefix}-{key}");
    }
}