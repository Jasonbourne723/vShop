using vShop.Apps.Application.DTOs;

namespace vShop.Apps.Application.Commands.Products
{
    public class CreateProductCommand : ICommand<ProductDto>
    {

        public string Name { get; set; }

        public string ProductNo { get; set; }

        public string Remark { get; set; }

        public decimal CosePrice { get; set; }

        public decimal SellPrice { get; set; }

        public string Style { get; set; }
    }
}
