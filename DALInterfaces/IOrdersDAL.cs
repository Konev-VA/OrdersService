using Models;

namespace DALInterfaces
{
    public interface IOrdersDAL
    {
        Task<Order> CreateOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<Order?> GetOrder(Guid id);

        void DeleteOrder(Guid id);
    }
}
