using AutoMapper;
using MediatR;
using vShop.Apps.Application.DTOs;
using vShop.Domain.Entities;
using vShop.Domain.Repositories;

namespace vShop.Apps.Application.Commands.Products
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        async Task<ProductDto> IRequestHandler<CreateProductCommand, ProductDto>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name,
                                      request.ProductNo,
                                      request.Remark,
                                      request.CosePrice,
                                      request.SellPrice,
                                      request.Style);

            product = await _productRepository.Add(product);

            await _productRepository.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }
    }
}
