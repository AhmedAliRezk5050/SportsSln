using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models;

public class StoreDbContext : DbContext
{
  public StoreDbContext(DbContextOptions<StoreDbContext> options)
  : base(options) { }

  // study
  public DbSet<Product> Products => Set<Product>();
}