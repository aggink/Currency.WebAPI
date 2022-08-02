namespace Сurrency.WebAPI.ViewModels;

/// <summary>
/// Currency data for ViewModel.
/// </summary>
public class CurrencyViewModel
{
    /// <summary>
    /// Currency ID.
    /// </summary>
    public string ID { get; init; } = null!;

    /// <summary>
    /// Digital currency code.
    /// </summary>
    public int NumCode { get; init; }

    /// <summary>
    /// The letter code of the currency.
    /// </summary>
    public string CharCode { get; init; } = null!;

    /// <summary>
    /// Currency denomination.
    /// </summary>
    public int Nominal { get; init; }

    /// <summary>
    /// The name of the currency.
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// The current exchange rate.
    /// </summary>
    public decimal Value { get; init; }

    /// <summary>
    /// The previous exchange rate.
    /// </summary>
    public decimal Previous { get; init; }
}