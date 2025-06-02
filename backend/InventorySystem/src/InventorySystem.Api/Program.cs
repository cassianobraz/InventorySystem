using InventorySystem.Api.Infrastructure;
using InventorySystem.Api.UseCases.Stocks.Delete;
using InventorySystem.Api.UseCases.Stocks.GetAll;
using InventorySystem.Api.UseCases.Stocks.Register;
using InventorySystem.Api.UseCases.Stocks.Update;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InventoryDBContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)),
        b => b.MigrationsAssembly("InventorySystem.Api")));

builder.Services.AddScoped<GetAllInventoryUseCase>();
builder.Services.AddScoped<RegisterInventoryUseCase>();
builder.Services.AddScoped<UpdateInventoryUseCase>();
builder.Services.AddScoped<DeleteInventoryUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .WithOrigins("https://teste-inventory.netlify.app")
            .WithHeaders("Content-Type", "Authorization", "X-Requested-With")
            .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseRouting();

app.UseCors("CorsPolicy");

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "https://teste-inventory.netlify.app");
    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        return;
    }

    await next();
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API V1");
    c.RoutePrefix = "swagger";
});

app.UseAuthorization();

app.MapControllers();

app.Run();
