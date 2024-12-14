namespace vShop.Apps.Application.DTOs
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }

        public string OrderNo { get; set; }

        public long ProductId { get; set; }

        public string ProductNo { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }

        public long UserId { get; set; }
    }
}
