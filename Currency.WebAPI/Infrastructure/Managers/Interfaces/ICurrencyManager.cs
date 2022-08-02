using Сurrency.WebAPI.Extensions.PagedList;
using Сurrency.WebAPI.ViewModels;

namespace Сurrency.WebAPI.Infrastructure.Managers.Interfaces;

/// <summary>
/// Interface for interacting with the currency manager.
/// </summary>
public interface ICurrencyManager
{
    /// <summary>
    /// Get information about the currency by code.
    /// </summary>
    /// <param name="code">Currency code.</param>
    /// <returns>Information about the currency.</returns>
    CurrencyViewModel? GetByCode(string code);

    /// <summary>
    /// Get a page with currencies.
    /// </summary>
    /// <param name="pageIndex">Page number.</param>
    /// <param name="pageSize">The number of elements on the page.</param>
    /// <returns>The page with currencies.</returns>
    IPagedList<CurrencyViewModel>? GetPagedList(int pageIndex, int pageSize);
}