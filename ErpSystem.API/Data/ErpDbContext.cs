using Microsoft.EntityFrameworkCore;
using ErpSystem.API.Models;

namespace ErpSystem.API.Data
{
    public class ErpDbContext : DbContext
    {
        public DbSet<CariAccount> CariAccounts { get; set; }

        public ErpDbContext(DbContextOptions<ErpDbContext> options)
            : base(options)
        {
        }

        // Tablolarımızı tanımlıyoruz
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<StockMovement> StockMovements { get; set; } = null!;
    }
}