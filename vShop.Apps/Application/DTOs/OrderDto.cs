namespace vShop.Apps.Application.DTOs
{
    public class OrderDto
    {
        public long Id { get; set; }
        public string OrderNo { get; set; }

        public long UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PayTime { get; set; }

        public DateTime CreateTime { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}
