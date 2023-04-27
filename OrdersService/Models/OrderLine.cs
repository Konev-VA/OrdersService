namespace OrdersService.Models
{
    public class OrderLine
    {
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid? OrderId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Order? Order { get; set; }

        public Guid ProductId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}
