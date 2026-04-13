using Microsoft.EntityFrameworkCore;
using InventarioCCL.api.Models;

namespace InventarioCCL.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}