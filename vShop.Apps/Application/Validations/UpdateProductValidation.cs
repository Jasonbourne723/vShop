using FluentValidation;
using vShop.Apps.Application.Commands.Products;

namespace vShop.Apps.Application.Validations
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            RuleFor(product => product.Id).NotNull().GreaterThan(0);
            RuleFor(product => product.Name).NotNull();
            RuleFor(product => product.ProductNo).NotNull();
            RuleFor(product => product.SellPrice).GreaterThan(0);
        }
    }
}
