using InventorySystem.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Api.Infrastructure;

public class InventoryDBContext : DbContext
{
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Cassiano\\ROCKET\\InventoryDb.db");
    }
}
