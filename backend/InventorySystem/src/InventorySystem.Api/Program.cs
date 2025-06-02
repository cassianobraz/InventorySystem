using InventorySystem.Api.Infrastructure;
using InventorySystem.Api.UseCases.Stocks.Delete;
using InventorySystem.Api.UseCases.Stocks.GetAll;
using InventorySystem.Api.UseCases.Stocks.Register;
using InventorySystem.Api.UseCases.Stocks.Update;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    options.ListenAnyIP(int.Parse(port));
});

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
        policy.WithOrigins("https://teste-inventory.netlify.app")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API V1");
    c.RoutePrefix = "swagger";
});

app.UseAuthorization();
app.MapControllers();

app.Run();
