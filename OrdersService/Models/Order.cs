using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace OrdersService.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; init; }

        public StatusType StatusType { get; set; } = StatusType.New;

        public string Status { get => StatusType.ToString(); }

        public DateTime Created { get; init; } = DateTime.Now;

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public bool? IsDeleted { get; set; } = false;

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Product> Lines { get; set; } = new();

        public List<OrderLine>? OrderLine { get; set; } = new();
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
