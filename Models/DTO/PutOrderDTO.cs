﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DTO
{
    [NotMapped]
    public class PutOrderDTO
    {
        public string Status { get; set; }
        public List<OrderLine> Lines { get; set; } = new();
    }
}
