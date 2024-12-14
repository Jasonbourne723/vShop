using AutoMapper;
using vShop.Apps.Application.DTOs;
using vShop.Domain.Repositories;

namespace vShop.Apps.Application.Commands.Products
{
    public class UpdateProductCommandHandlder : ICommandHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandlder(IMapper mapper, IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            if (product == null)
            {
                throw new FluentValidation.ValidationException($"未找到相关商品,商品Id:{request.Id}");
            }

            product.Update(request.Name,
                           request.ProductNo,
                           request.Remark,
                           request.CosePrice,
                           request.SellPrice,
                           request.Style);
            product = await _productRepository.Update(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }
    }
}
