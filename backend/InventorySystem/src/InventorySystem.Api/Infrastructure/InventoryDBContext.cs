using InventorySystem.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Api.Infrastructure;

public class InventoryDBContext : DbContext
{
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=hopper.proxy.rlwy.net;port=27041;database=railway;user=root;password=luYhHqOzBWWUFhDJEcecLlsVAvKLaYKg;";

        optionsBuilder.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 30)),
            b => b.MigrationsAssembly("InventorySystem.Api")
        );
    }
}