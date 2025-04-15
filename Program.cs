using Microsoft.EntityFrameworkCore;
using WebCoreApi_Login_Net8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In-memory database for testing
builder.Services.AddDbContext<mydbcontext>(options =>
    options.UseInMemoryDatabase("TestDb"));

var app = builder.Build();

// Enable Swagger in all environments (temporary)
app.UseSwagger();
app.UseSwaggerUI();

// Authorization (if needed)
app.UseAuthorization();

// Map controller endpoints
app.MapControllers();

// Run on Railway's provided port
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");
