using Microsoft.Extensions.Caching.Distributed;
using vShop.Domain.Entities;
using vShop.Domain.Repositories;

namespace vShop.Infrastructure.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(EFContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
        }
    }
}
