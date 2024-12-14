using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vShop.Apps.Application.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ProductNo { get; set; }

        public string Remark { get; set; }

        public decimal CosePrice { get; set; }

        public decimal SellPrice { get; set; }

        public string Style { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
