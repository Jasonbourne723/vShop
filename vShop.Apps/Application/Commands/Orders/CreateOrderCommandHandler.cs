using AutoMapper;
using vShop.Apps.Application.Commands;
using vShop.Domain.Entities;
using vShop.Domain.Repositories;

namespace vShop.Apps.Application.Commands.Orders
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, long>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // 校验商品信息、价格

            // 判断库存


            var order = new Order(request.OrderNo,
                                  request.UserId,
                                  request.TotalAmount,
                                  request.PayTime);

            order = await _orderRepository.Add(order);

            foreach (var item in request.Items)
            {
                order.AddOrderItem(item.ProductId, item.Quantity, item.UnitPrice, item.TotalAmount);
            }

            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
