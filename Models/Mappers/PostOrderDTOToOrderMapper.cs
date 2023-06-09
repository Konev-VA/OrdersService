﻿using Models.DTO;

namespace Models.Mappers
{
    public class PostOrderDTOToOrderMapper
    {
        public static Order MapPostOrderDTOToOrder(PostOrderDTO postOrderDTO)
        {
            return new Order()
            {
                Id = postOrderDTO.Id,
                Created = DateTime.UtcNow,
                IsDeleted = false,
                Lines = postOrderDTO.Lines,
                StatusType = StatusType.New
            };
        }
    }
}
