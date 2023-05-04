namespace Models
{
    public class OrderLine
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid? OrderId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Order? Order { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Guid ProductId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Product? Product { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("qty")]
        public int Quantity { get; set; }
    }
}