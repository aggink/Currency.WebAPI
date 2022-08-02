namespace Сurrency.WebAPI.Models;

/// <summary>
/// Currency data.
/// </summary>
public class Currency
{
    /// <summary>
    /// Currency ID.
    /// </summary>
    public string ID { get; set; } = null!;

    /// <summary>
    /// Digital currency code.
    /// </summary>
    public int NumCode { get; set; }

    /// <summary>
    /// The letter code of the currency.
    /// </summary>
    public string CharCode { get; set; } = null!;

    /// <summary>
    /// Currency denomination.
    /// </summary>
    public int Nominal { get; set; }

    /// <summary>
    /// The name of the currency.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// The current exchange rate.
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// The previous exchange rate.
    /// </summary>
    public decimal Previous { get; set; }
}