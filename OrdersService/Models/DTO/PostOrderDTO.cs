namespace OrdersService.Models.DTO
{
    public class PostOrderDTO
    {
        public Guid Id { get; set; }
        public List<OrderLine> Lines { get; set; }
    }
}
