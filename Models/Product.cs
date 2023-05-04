using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Order> Orders { get; set; } = new();

        [System.Text.Json.Serialization.JsonIgnore]
        public List<OrderLine> OrderLine { get; set; } = new();
    }
}
