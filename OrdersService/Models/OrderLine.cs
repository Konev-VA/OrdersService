using System.ComponentModel.DataAnnotations;

namespace OrdersService.Models
{
    public class OrderLine
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public List<Order> Orders { get; } = new();
    }
}
