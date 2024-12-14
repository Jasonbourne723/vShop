using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vShop.Domain.Entities
{
    public class OrderItem : Entity
    {
        public long OrderId { get; set; }
        [StringLength(20)]
        public string OrderNo { get; set; }

        public long ProductId { get; set; }

        public string ProductNo { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; set; }

        public long UserId { get; set; }
    }

}
