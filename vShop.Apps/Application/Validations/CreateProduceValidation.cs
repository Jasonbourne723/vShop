using FluentValidation;
using vShop.Apps.Application.Commands.Products;
using vShop.Domain.Entities;

namespace vShop.Apps.Application.Validations
{
    public class CreateProduceValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProduceValidation()
        {
            RuleFor(product => product.Name).NotNull();
            RuleFor(product => product.ProductNo).NotNull();
            RuleFor(product => product.SellPrice).GreaterThan(0);
        }
    }
}
