﻿using OrdersService.Models;

namespace OrdersService.DAL
{
    public interface IOrdersDAL
    {
        Task<Order> CreateOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<Order> GetOrder(Guid id);

        Task DeleteOrder(Guid id);
    }
}