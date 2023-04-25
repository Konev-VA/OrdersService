
using OrdersService.Models;

namespace OrdersService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            using (ApplicationContext db = new ApplicationContext())
            {
                OrderLine orderLine = new OrderLine() { Id = Guid.NewGuid(), Quantity = 12 };

                OrderLine orderLine2 = new OrderLine() { Id = Guid.NewGuid(), Quantity = 5 };

                db.OrderLines.AddRange(orderLine, orderLine2);

                db.SaveChanges();

                Order order = new Order() { Id = Guid.NewGuid(), DateTime = DateTime.Now, Lines = new List<OrderLine> { orderLine }, Status = StatusType.New };

                Order order2 = new Order() { Id = Guid.NewGuid(), DateTime = DateTime.Now, Lines = new List<OrderLine> { orderLine2 }, Status = StatusType.Paid };
                Order order3 = new Order() { Id = Guid.NewGuid(), DateTime = DateTime.Now, Lines = new List<OrderLine> { orderLine2 }, Status = StatusType.Completed };

                db.Orders.AddRange(order, order2, order3);

                //db.Orders.Add(order2);

                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var orderLines = db.OrderLines.ToList();

                Console.WriteLine("Кол-во записей: " + orderLines.Count);
            }
        
            app.Run();

        }
    }
}