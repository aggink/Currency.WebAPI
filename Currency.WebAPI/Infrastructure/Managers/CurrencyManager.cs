using Сurrency.WebAPI.Extensions.PagedList;
using Сurrency.WebAPI.Infrastructure.Managers.Interfaces;
using Сurrency.WebAPI.Infrastructure.Providers.Interfaces;
using Сurrency.WebAPI.ViewModels;

namespace Сurrency.WebAPI.Infrastructure.Managers;

/// <summary>
/// Currency manager.
/// </summary>
public class CurrencyManager : ICurrencyManager
{
    private readonly ICurrencyProvider _currencyProvider;
    public CurrencyManager(ICurrencyProvider currencyProvider)
    {
        _currencyProvider = currencyProvider;
    }

    /// <summary>
    /// Get information about the currency by code.
    /// </summary>
    /// <param name="code">Currency code.</param>
    /// <returns>Information about the currency.</returns>
    public CurrencyViewModel? GetByCode(string code)
    {
        var currency = _currencyProvider.GetByCode(code);
        if(currency == null) return null;
        return new CurrencyViewModel()
        {
            ID = currency.ID,
            CharCode = currency.CharCode,
            Name = currency.Name,
            Nominal = currency.Nominal,
            NumCode = currency.NumCode,
            Previous = currency.Previous,
            Value = currency.Value
        };
    }

    /// <summary>
    /// Get a page with currencies.
    /// </summary>
    /// <param name="pageIndex">Page number.</param>
    /// <param name="pageSize">The number of elements on the page.</param>
    /// <returns>The page with currencies.</returns>
    public IPagedList<CurrencyViewModel>? GetPagedList(int pageIndex, int pageSize)
    {
        if (pageIndex <= 0 || pageSize <= 0) return null;

        var pageList = _currencyProvider.GetPagedList(pageIndex, pageSize);
        if (pageList == null) return null;

        return new PagedList<CurrencyViewModel>()
        {
            PageIndex = pageList.PageIndex,
            PageSize = pageList.PageSize,
            TotalCount = pageList.TotalCount,
            TotalPages = pageList.TotalPages,
            StartIndex = pageList.StartIndex,
            Items = pageList.Items.Select(currency => new CurrencyViewModel()
            {
                ID = currency.ID,
                CharCode = currency.CharCode,
                Name = currency.Name,
                Nominal = currency.Nominal,
                NumCode = currency.NumCode,
                Previous = currency.Previous,
                Value = currency.Value
            }).ToList()
        };
    }
}