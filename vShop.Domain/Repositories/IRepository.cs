using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using vShop.Domain.Entities;
using vShop.Infrastructure.Repositories;

namespace vShop.Domain.Repositories
{
    public interface IRepository<T, TIdentity> where T : Entity<TIdentity>, new()
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task Delete(TIdentity id);

        Task<T?> Get(TIdentity id);
    }

    public interface IRepository<T> : IRepository<T, long> where T : Entity<long>, new()
    {

    }
}
