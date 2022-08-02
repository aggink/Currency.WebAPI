namespace Сurrency.WebAPI.Models;

/// <summary>
/// Information about exchange rates.
/// </summary>
public class InfoCurrencies
{
    /// <summary>
    /// Time to update the data on exchange rates.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The previous time to update data on exchange rates.
    /// </summary>
    public DateTime PreviousDate { get; set; }

    /// <summary>
    /// Link to previous data on exchange rates.
    /// </summary>
    public string PreviousURL { get; set; } = null!;

    /// <summary>
    /// Last update of the database of the Central Bank of the Russian Federation.
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Exchange rates from the Central Bank of the Russian Federation.
    /// </summary>
    public IList<Currency> Currencies { get; set; } = null!;
}