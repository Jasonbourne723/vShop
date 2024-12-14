using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vShop.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(long productId,  int quantity, decimal unitPrice, decimal totalAmount)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalAmount = totalAmount;
        }

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; set; }
    }

}
