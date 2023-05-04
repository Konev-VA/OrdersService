using Models;

namespace BLLInterfaces
{
    public interface IOrdersBLL
    {
        Task<ServiceResult<Order>> CreateOrder(Order order);

        Task<ServiceResult<Order>> UpdateOrder(Order order);

        Task<ServiceResult<Order>> GetOrder(Guid id);

        Task<ServiceResult<Order>> DeleteOrder(Guid id);
    }
}
