namespace MyWeb.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
