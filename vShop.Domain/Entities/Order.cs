using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vShop.Domain.Entities
{
    public class Order : Entity
    {
        public Order()
        {
        }

        public Order(string orderNo, long userId, decimal totalAmount, DateTime payTime)
        {
            OrderNo = orderNo;
            UserId = userId;
            TotalAmount = totalAmount;
            PayTime = payTime;
            _items = new List<OrderItem>();
        }
        [StringLength(20)]
        public string OrderNo { get; set; }

        public long UserId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime PayTime { get; set; }

        private List<OrderItem> _items;

        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public void AddOrderItem(long productId, int quantity, decimal unitPrice, decimal totalAmount)
        {
            if (_items.Exists(x => x.ProductId == productId)) return;

            var orderItem = new OrderItem(productId, quantity, unitPrice, totalAmount);
            _items.Add(orderItem);
        }

    }

}
