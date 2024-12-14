using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vShop.Domain.Entities
{
    public class Product : Entity
    {
        public Product()
        {
        }

        public Product(string name, string productNo, string remark, decimal cosePrice, decimal sellPrice, string style)
        {
            Name = name;
            ProductNo = productNo;
            Remark = remark;
            CosePrice = cosePrice;
            SellPrice = sellPrice;
            Style = style;
        }

        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string ProductNo { get; set; }
        [StringLength(50)]
        public string Remark { get; set; }
        [Column(TypeName ="decimal(12,2)")]
        public decimal CosePrice { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal SellPrice { get; set; }
        [StringLength(50)]
        public string Style { get; set; }

        public void Update(string name, string productNo, string remark, decimal cosePrice, decimal sellPrice, string style)
        {
            Name = name;
            ProductNo = productNo;
            Remark = remark;
            CosePrice = cosePrice;
            SellPrice = sellPrice;
            Style = style;
        }

    }

}
