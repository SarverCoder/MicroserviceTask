namespace OrderService.DataAccess.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
