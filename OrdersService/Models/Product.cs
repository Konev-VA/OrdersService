using System.ComponentModel.DataAnnotations;

namespace OrdersService.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Order> Orders { get; set; } = new();

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public List<OrderLine> OrderLine { get; set; } = new();
    }
}
