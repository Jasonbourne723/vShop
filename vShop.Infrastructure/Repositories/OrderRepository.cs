using Microsoft.Extensions.Caching.Distributed;
using vShop.Domain.Entities;
using vShop.Domain.Repositories;

namespace vShop.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EFContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
        }
    }
}
