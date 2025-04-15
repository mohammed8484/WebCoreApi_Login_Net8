using Microsoft.EntityFrameworkCore;
using WebCoreApi_Login_Net8.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services to the container BEFORE calling Build()
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<mydbcontext>(options =>
    options.UseInMemoryDatabase("TestDb"));

var app = builder.Build();

// ✅ Configure the middleware pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

// ✅ Support Railway PORT
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");
