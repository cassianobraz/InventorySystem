using InventorySystem.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Api.Infrastructure;

public class InventoryDBContext : DbContext
{
    public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base(options) { }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<User> Users { get; set; }
}