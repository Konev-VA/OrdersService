
using Microsoft.EntityFrameworkCore;
using OrdersService.BLL;
using OrdersService.DAL;
using OrdersService.Exceptions;
using OrdersService.Models;

namespace OrdersService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IOrdersDAL, OrdersDAL>();
            builder.Services.AddSingleton<IOrdersBLL, OrdersBLL>();

            string connectionString = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("Postgres") ?? throw new ConnectionStringException("Строка подключения не задана");

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql(connectionString)
                .Options;

            builder.Services.AddTransient<ApplicationContext>(provider => new ApplicationContext(options));

            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.Run();

        }
    }
}