namespace vShop.Apps.Application.DTOs
{
    public class OrderItemDto
    {

        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }

    }
}
