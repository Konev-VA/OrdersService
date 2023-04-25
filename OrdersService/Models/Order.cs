using System.ComponentModel.DataAnnotations;

namespace OrdersService.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; init; }

        public StatusType Status { get; set; }


        public DateTime DateTime { get; init; }

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
