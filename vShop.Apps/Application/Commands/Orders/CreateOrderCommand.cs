using vShop.Apps.Application.DTOs;

namespace vShop.Apps.Application.Commands.Orders
{
    public class CreateOrderCommand : ICommand<long>
    {
        public string OrderNo { get; set; }

        public long UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PayTime { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
