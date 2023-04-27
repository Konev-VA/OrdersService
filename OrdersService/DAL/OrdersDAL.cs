using Microsoft.EntityFrameworkCore;
using OrdersService.Models;

namespace OrdersService.DAL
{
    public class OrdersDAL : IOrdersDAL
    {

        private ApplicationContext db;

        public OrdersDAL(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                await db.Orders.AddAsync(order);

                db.SaveChanges();

                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await db.Orders.Include(x => x.Lines)
                .FirstOrDefaultAsync((x) => x.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var result = await db.Orders.Where((x) => x.Id == order.Id).FirstOrDefaultAsync();

            result.StatusType = order.StatusType;
            result.Lines = order.Lines;
            result.IsDeleted = order.IsDeleted;

            db.SaveChanges();

            return result;
        }
    }
}
