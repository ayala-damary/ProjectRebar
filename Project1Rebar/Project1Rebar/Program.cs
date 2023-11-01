using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project1Rebar.Models;
using Project1Rebar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<RebarDatabaseSetting>(
    builder.Configuration.GetSection(nameof(RebarDatabaseSetting)));
builder.Services.AddSingleton<IRebarDatabaseSetting>(sp => sp.GetRequiredService<IOptions<RebarDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<String>("RebarDatabaseSetting:ConnectionString")));

builder.Services.AddScoped<IShakeService, ShakeService>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();


