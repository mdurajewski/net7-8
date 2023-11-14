using System.Runtime.InteropServices.ComTypes;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.UseRateLimiter(new RateLimiterOptions
{
    GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
    {
        //if (context.Request.Path == "/info")
        //{
        //    return RateLimitPartition.GetNoLimiter("Unlimited");
        //}

        return RateLimitPartition.GetConcurrencyLimiter("GeneralLimit",
            _ => new ConcurrencyLimiterOptions
            { PermitLimit = 10, QueueLimit = 20, QueueProcessingOrder = QueueProcessingOrder.OldestFirst });
    }),
    RejectionStatusCode = 429
});

//app.UseRateLimiter(new RateLimiterOptions
//{
//    GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
//    {
//        if (context.Request.Path == "/info")
//        {
//            return RateLimitPartition.GetNoLimiter("Unlimited");
//        }

//        return RateLimitPartition.GetTokenBucketLimiter("TokenLimit",
//            _ => new TokenBucketRateLimiterOptions
//            { 
//                TokenLimit = 10, 
//                QueueProcessingOrder = QueueProcessingOrder.OldestFirst, 
//                QueueLimit = 0, 
//                ReplenishmentPeriod = TimeSpan.FromSeconds(10), 
//                TokensPerPeriod = 10, 
//                AutoReplenishment = true });
//    }),
//    RejectionStatusCode = 429
//});

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
