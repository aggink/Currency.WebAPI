using Microsoft.Extensions.Caching.Memory;
using Сurrency.WebAPI.Extensions.PagedList;
using Сurrency.WebAPI.Infrastructure.AppStart;
using Сurrency.WebAPI.Infrastructure.Providers.Interfaces;
using Сurrency.WebAPI.Models;

namespace Сurrency.WebAPI.Infrastructure.Providers;

/// <summary>
/// The class that provides functionality for processing requests for extracting currency data from cache memory.
/// </summary>
public class CurrencyProvider : ICurrencyProvider
{
    private readonly IMemoryCache _memoryCache;
    public CurrencyProvider(IMemoryCache memoryCache)
    {
        MemoryCacheKey = MemoryCacheData.CurrencyKey;
        _memoryCache = memoryCache;
    }

    #region Fields

    /// <summary>
    /// The key for caching data.
    /// </summary>
    private readonly string MemoryCacheKey;

    #endregion

    /// <summary>
    /// Get information about the currency by code.
    /// </summary>
    /// <param name="code">Currency code.</param>
    /// <returns>Information about the currency.</returns>
    public Currency? GetByCode(string code)
    {
        var info = GetInfoInfoCurrencies();
        if(info == null) return null;

        return info.Currencies.FirstOrDefault(x =>
                x.ID.Contains(code, StringComparison.OrdinalIgnoreCase) ||
                x.CharCode.Contains(code, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Get a page with currencies.
    /// </summary>
    /// <param name="pageIndex">Page number.</param>
    /// <param name="pageSize">The number of elements on the page.</param>
    /// <returns>The page with currencies.</returns>
    public IPagedList<Currency>? GetPagedList(int pageIndex, int pageSize)
    {
        try
        {
            var info = GetInfoInfoCurrencies();
            if (info == null) return null;

            return new PagedList<Currency>(pageIndex, pageSize, info.Currencies);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Get information about currencies from the cache.
    /// </summary>
    /// <returns>Information about currencies.</returns>
    private InfoCurrencies? GetInfoInfoCurrencies()
    {
        if(!_memoryCache.TryGetValue(MemoryCacheKey, out InfoCurrencies infoCurrencies)) return null;
        return infoCurrencies;
    }

}