using �urrency.WebAPI.Infrastructure.Managers;
using �urrency.WebAPI.Infrastructure.Managers.Interfaces;
using �urrency.WebAPI.Infrastructure.Providers;
using �urrency.WebAPI.Infrastructure.Providers.Interfaces;
using �urrency.WebAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

//logger

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddHostedService<CurrencyBackgroundService>();
builder.Services.AddTransient<ICurrencyProvider, CurrencyProvider>();
builder.Services.AddTransient<ICurrencyManager, CurrencyManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();