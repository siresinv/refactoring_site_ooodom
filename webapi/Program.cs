//using DBContext.Entities;
using Microsoft.EntityFrameworkCore;
using DBContext;
//using DBContext.MappingProfiles;
using webapi.MappingProfiles;
//using Au

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<CompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
        "Server=(localdb)\\mssqllocaldb;Database=CompanyDom;Trusted_Connection=True;"));

builder.Services.AddAutoMapper(cfg => { }, typeof(AppMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseRouting();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", (CompanyDbContext db) => db.Phones.ToList());

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
