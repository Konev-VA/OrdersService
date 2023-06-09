﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; init; }

        [System.Text.Json.Serialization.JsonIgnore]
        public StatusType StatusType { get; set; } = StatusType.New;

        public string Status { get => StatusType.ToString(); }

        public DateTime Created { get; init; } = DateTime.UtcNow;

        [System.Text.Json.Serialization.JsonIgnore]
        public bool IsDeleted { get; set; } = false;

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Product> Products { get; set; } = new();

        public List<OrderLine> Lines { get; set; } = new();
    }

    public enum StatusType
    {
        New,
        WaitingForPayment,
        Paid,
        InDelivery,
        Delivered,
        Completed
    }
}
