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
            var items = _mapper.Map<List<OrderItem>>(request.Items);

            var order = new Order(request.OrderNo,
                                  request.UserId,
                                  request.TotalAmount,
                                  request.PayTime,
                                  items);

            order = await _orderRepository.Add(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
