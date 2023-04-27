﻿using OrdersService.Models;
using OrdersService.Models.DTO;

namespace OrdersService.Mappers
{
    public class PostOrderDTOToOrderMapper
    {
        public static Order MapPostOrderDTOToOrder(PostOrderDTO postOrderDTO)
        {
            return new Order()
            {
                Id = postOrderDTO.Id,
                Created = DateTime.Now,
                IsDeleted = false,
                OrderLine = postOrderDTO.Lines,
                StatusType = StatusType.New
            };
        }
    }
}