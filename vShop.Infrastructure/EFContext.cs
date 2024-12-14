using Microsoft.EntityFrameworkCore;
using vShop.Domain.Entities;
using vShop.Infrastructure.Repositories;

namespace vShop.Infrastructure
{
    public class EFContext : DbContext, IUnitOfWork
    {
        public EFContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }


    }
}
