using Microsoft.Extensions.Caching.Distributed;
using vShop.Domain.Entities;
using vShop.Domain.Repositories;

namespace vShop.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EFContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
        }
    }
}
