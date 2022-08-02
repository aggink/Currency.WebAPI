namespace Сurrency.WebAPI.Extensions.PagedList;

/// <summary>
/// Implementing the paginated list.
/// </summary>
/// <typeparam name="T">Page list type.</typeparam>
public class PagedList<T> : IPagedList<T>
{
    public PagedList(int pageIndex, int pageSize, IEnumerable<T> source, int startIndex = 1)
    {
        if (pageIndex < startIndex) throw new ArgumentException($"The page number ({pageIndex}) cannot be less than the start page number ({StartIndex}).");

        PageIndex = pageIndex;
        PageSize = pageSize;
        StartIndex = startIndex;

        if (source is IQueryable<T> queryable)
        {
            TotalCount = queryable.Count();
            Items = queryable.Skip((PageIndex - StartIndex) * PageSize).Take(PageSize).ToList();
        }
        else
        {
            TotalCount = source.Count();
            Items = source.Skip((PageIndex - StartIndex) * PageSize).Take(PageSize).ToList();
        }

        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

        if (pageIndex > TotalPages) throw new ArgumentException($"The page number ({pageIndex}) is greater than the total count ({TotalPages}) of pages.");
    }

    public PagedList()
    {
        Items = new List<T>();
    }

    #region Properties

    /// <summary>
    /// Get the page number of the list.
    /// </summary>
    /// <value>Page number.</value>
    public int PageIndex { get; init; }

    /// <summary>
    /// Get the number of items on the page.
    /// </summary>
    /// <value>The number of elements on the page.</value>
    public int PageSize { get; init; }

    /// <summary>
    /// Get the number of all items in the list.
    /// </summary>
    /// <value>Number of items in the list.</value>
    public int TotalCount { get; init; }

    /// <summary>
    /// Get the number of pages.
    /// </summary>
    /// <value>Number of pages.</value>
    public int TotalPages { get; init; }

    /// <summary>
    /// Get the start page number.
    /// </summary>
    /// <value>Start page number.</value>
    public int StartIndex { get; init; }

    /// <summary>
    ///  Gets the current page items.
    /// </summary>
    /// <value>Current elements on the page.</value>
    public IList<T> Items { get; init; }

    /// <summary>
    /// Get the previous page.
    /// </summary>
    /// <value>True - It has the previous page. False - It doesn't have the previous page.</value>
    public bool HasPreviousPage => PageIndex - StartIndex > 0;

    /// <summary>
    /// Get the next page.
    /// </summary>
    /// <value>True - It has the next page. False - It doesn't have the next page.</value>
    public bool HasNextPage => PageIndex - StartIndex + 1 < TotalPages;

    #endregion
}