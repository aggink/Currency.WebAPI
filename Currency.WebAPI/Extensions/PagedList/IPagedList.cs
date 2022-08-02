namespace Сurrency.WebAPI.Extensions.PagedList;

/// <summary>
/// The interface that provides access to the page list.
/// </summary>
/// <typeparam name="T">List data type.</typeparam>
public interface IPagedList<T>
{
    /// <summary>
    /// Get the page number of the list.
    /// </summary>
    /// <value>Page number.</value>
    int PageIndex { get; init; }

    /// <summary>
    /// Get the number of items on the page.
    /// </summary>
    /// <value>The number of elements on the page.</value>
    int PageSize { get; init; }

    /// <summary>
    /// Get the number of all items in the list.
    /// </summary>
    /// <value>Number of items in the list.</value>
    int TotalCount { get; init; }

    /// <summary>
    /// Get the number of pages.
    /// </summary>
    /// <value>Number of pages.</value>
    int TotalPages { get; init; }

    /// <summary>
    /// Get the start page number.
    /// </summary>
    /// <value>Start page number.</value>
    int StartIndex { get; init; }

    /// <summary>
    ///  Gets the current page items.
    /// </summary>
    /// <value>Current elements on the page.</value>
    IList<T> Items { get; init; }

    /// <summary>
    /// Get the previous page.
    /// </summary>
    /// <value>True - It has the previous page. False - It doesn't have the previous page.</value>
    bool HasPreviousPage { get; }

    /// <summary>
    /// Get the next page.
    /// </summary>
    /// <value>True - It has the next page. False - It doesn't have the next page.</value>
    bool HasNextPage { get; }
}