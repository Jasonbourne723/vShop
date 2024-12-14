using Microsoft.Extensions.Caching.Distributed;
using vShop.Domain.Entities;
using vShop.Domain.Repositories;

namespace vShop.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly EFContext _context;

        public OrderRepository(EFContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
            this._context = context;
        }

        public override async Task<Order?> Get(long id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                await _context.Entry(order).Collection(i => i.Items).LoadAsync();
            }
            return order;
        }
    }
}
