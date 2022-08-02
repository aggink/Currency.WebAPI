using Сurrency.WebAPI.Extensions.PagedList;
using Сurrency.WebAPI.Models;

namespace Сurrency.WebAPI.Infrastructure.Providers.Interfaces;

/// <summary>
/// The interface that provides methods for interacting with currency data.
/// </summary>
public interface ICurrencyProvider
{
    /// <summary>
    /// Get information about the currency by code.
    /// </summary>
    /// <param name="code">Currency code.</param>
    /// <returns>Information about the currency.</returns>
    Currency? GetByCode(string code);

    /// <summary>
    /// Get a page with currencies.
    /// </summary>
    /// <param name="pageIndex">Page number.</param>
    /// <param name="pageSize">The number of elements on the page.</param>
    /// <returns>The page with currencies.</returns>
    IPagedList<Currency>? GetPagedList(int pageIndex, int pageSize);
}