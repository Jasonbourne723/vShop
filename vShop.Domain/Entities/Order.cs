using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vShop.Domain.Entities
{
    public class Order : Entity
    {
        public Order()
        {
        }

        public Order(string orderNo, long userId, decimal totalAmount, DateTime payTime, List<OrderItem> items)
        {
            OrderNo = orderNo;
            UserId = userId;
            TotalAmount = totalAmount;
            PayTime = payTime;
            Items = items;
        }
        [StringLength(20)]
        public string OrderNo { get; set; }

        public long UserId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime PayTime { get; set; }

        public List<OrderItem> Items { get; set; }

    }

}
