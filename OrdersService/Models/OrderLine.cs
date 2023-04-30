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

        [Newtonsoft.Json.JsonProperty("id")]
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Guid ProductId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Product? Product { get; set; }

        [Newtonsoft.Json.JsonProperty("qty")]
        [System.Text.Json.Serialization.JsonPropertyName("qty")]
        public int Quantity { get; set; }
    }
}