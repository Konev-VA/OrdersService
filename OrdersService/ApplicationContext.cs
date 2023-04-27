using Microsoft.EntityFrameworkCore;
using OrdersService.Models;

namespace OrdersService
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<OrderLine> OrderLines { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ordersdb;Username=postgres;Password=postgres");
        //}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Only for Test 
            modelBuilder.Entity<Product>().HasData(new { Id = new Guid("7054e065-946f-4c07-b603-9a50103acaae"), Name = "Notebook" },
                                                   new { Id = new Guid("eccea7ae-ed79-4848-b205-c05b9cad362d"), Name = "Computer" },
                                                   new { Id = new Guid("946f34f1-af13-4557-9743-39d4beca44fb"), Name = "Phone" });

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Lines)
                .WithMany(p => p.Orders)
                .UsingEntity<OrderLine>(
                product => product
                .HasOne(ol => ol.Product)
                .WithMany(p => p.OrderLine)
                .HasForeignKey(ol => ol.ProductId),
                order => order
                .HasOne(ol => ol.Order)
                .WithMany(o => o.OrderLine)
                .HasForeignKey(ol => ol.OrderId));

            //modelBuilder.Entity<Order>()
            //.HasMany(c => c.Lines) 
            //        .WithMany(s => s.Orders)
            //        .UsingEntity<OrderLine>(
            //    orderLine => orderLine
            //        .HasOne(pa => pa.OrderLine)
            //        .WithMany(p => p.OrderLineOrders)
            //        .HasForeignKey(pa => pa.OrderLineId),
            //    order => order
            //        .HasOne(pa => pa.Order)
            //        .WithMany(a => a.OrderLineOrders)
            //        .HasForeignKey(pa => pa.OrderId)
            //   );
        }
    }
}
