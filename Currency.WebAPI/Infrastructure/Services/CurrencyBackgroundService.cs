using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Сurrency.WebAPI.Infrastructure.AppStart;
using Сurrency.WebAPI.Models;

namespace Сurrency.WebAPI.Infrastructure.Services;

/// <summary>
/// The service for obtaining data on exchange rates from the Central Bank of the Russian Federation.
/// </summary>
public class CurrencyBackgroundService : BackgroundService
{
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<CurrencyBackgroundService> _logger;

    public CurrencyBackgroundService(
        IMemoryCache memoryCache, 
        ILogger<CurrencyBackgroundService> logger)
    {
        _memoryCache = memoryCache;
        _logger = logger;

        MemoryCacheKey = MemoryCacheData.CurrencyKey;

        Client = new HttpClient() { BaseAddress = new Uri(URL) };
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    #region Fields

    /// <summary>
    /// Client for sending HTTP requests to the service of the Central Bank of the Russian Federation.
    /// </summary>
    private readonly HttpClient Client;

    /// <summary>
    /// URL for getting data on currency exchange rates.
    /// </summary>
    private const string URL = "https://www.cbr-xml-daily.ru/daily_json.js";

    /// <summary>
    /// The key for caching data.
    /// </summary>
    private readonly string MemoryCacheKey;

    /// <summary>
    /// The expiration time (milliseconds) of the cache entry.
    /// </summary>
    private const int CacheMemoryExpirationTime = 3900000;

    /// <summary>
    /// The waiting time (milliseconds) for the task completion.
    /// </summary>
    private const int TaskWaitingTime = CacheMemoryExpirationTime - 300000;

    /// <summary>
    /// Waiting time (milliseconds) between requests to the Central Bank of the Russian Federation.
    /// </summary>
    private const int WaitTimeRequestCentralBank = 200;

    #endregion

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var response = await Client.GetAsync(URL, stoppingToken);
                if (!response.IsSuccessStatusCode) throw new ArgumentException(nameof(response));

                var json = await response.Content.ReadAsStringAsync(stoppingToken);
                if(json == null) throw new ArgumentException(nameof(json));

                var jObject = JObject.Parse(json);
                var infoCurrencies = new InfoCurrencies()
                {
                    Date = jObject.Value<DateTime>("Date"),
                    PreviousDate = jObject.Value<DateTime>("PreviousDate"),
                    PreviousURL = jObject.Value<string>("PreviousURL")!,
                    Timestamp = jObject.Value<DateTime>("Timestamp"),
                    Currencies = jObject.Children().Children().Children().Children().Select(item => new Currency()
                    {
                        ID = item.Value<string>("ID")!,
                        CharCode = item.Value<string>("CharCode")!,
                        Name = item.Value<string>("Name")!,
                        NumCode = item.Value<int>("NumCode"),
                        Previous = item.Value<decimal>("Previous"),
                        Nominal = item.Value<int>("Nominal"),
                        Value = item.Value<decimal>("Value")
                    }).ToList()
                };

                _memoryCache.Set(MemoryCacheKey, infoCurrencies, TimeSpan.FromMilliseconds(CacheMemoryExpirationTime));

                _logger.LogInformation($"Information about currencies has been received from the service of the Central Bank of the Russian Federation.");
                await Task.Delay(TaskWaitingTime, stoppingToken);
            }
            catch
            {
                
                _logger.LogInformation("Error when receiving information from the service of the Central Bank of the Russian Federation.");
                await Task.Delay(WaitTimeRequestCentralBank, stoppingToken);
            }
        }
    }
}