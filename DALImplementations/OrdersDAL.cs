using DALInterfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DALImplementations
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
            using var transaction = db.Database.BeginTransaction();

            try
            {
                await db.Orders.AddAsync(order);

                await db.SaveChangesAsync();

                await transaction.CommitAsync();

                return order;
            }
            catch (Exception)
            {
                db.Entry(order).State = EntityState.Detached;

                transaction.Rollback();

                throw;
            }

        }

        public async void DeleteOrder(Guid id)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                db.Orders.Remove(db.Orders.FirstOrDefault(o => o.Id == id)!);

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }

        public async Task<Order?> GetOrder(Guid id)
        {
            return await db.Orders.Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                var result = await db.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);

                result.StatusType = order.StatusType;
                result.Products = order.Products;
                result.Lines = order.Lines;
                result.IsDeleted = order.IsDeleted;

                await db.SaveChangesAsync();
                await transaction.CommitAsync();

                return result;
            }
            catch (Exception)
            {
                db.Entry(order).State = EntityState.Detached;

                await transaction.RollbackAsync();

                throw;
            }
        }
    }
}
