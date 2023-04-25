using Microsoft.EntityFrameworkCore;
using OrdersService.Models;

namespace OrdersService
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderLine> OrderLines { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ordersdb;Username=postgres;Password=postgres");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
