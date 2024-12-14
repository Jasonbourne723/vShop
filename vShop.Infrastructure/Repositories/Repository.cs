using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using vShop.Domain.Entities;
using vShop.Domain.Repositories;

namespace vShop.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity<long>, new()
    {
        private readonly EFContext _context;
        private readonly IDistributedCache _distributedCache;

        public IUnitOfWork UnitOfWork => _context;

        public Repository(EFContext context, IDistributedCache distributedCache)
        {
            this._context = context;
            this._distributedCache = distributedCache;
        }



        public async Task<T> Add(T entity)
        {
            var entry = await _context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public async Task Delete(long id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                return;
            }
            _context.Set<T>().Remove(entity);
            await DeleteCache<T>(entity.Id);
        }

        public virtual async Task<T?> Get(long id)
        {
            var result = await GetCache<T>(id);
            if (result == null)
            {
                result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                {
                    await SetCahce(id, result);
                }
            }
            return result;
        }


        public async Task<T> Update(T entity)
        {
            var entry = _context.Set<T>().Update(entity);
            await DeleteCache<T>(entity.Id);
            return await Task.FromResult(entry.Entity);
        }

        private async Task<T?> GetCache<T>(long id) where T : class, new()
        {
            var key = $"{typeof(T).Name}:Id:{id}";
            var bytes = await _distributedCache.GetAsync(key);
            if (bytes == null)
            {
                return default(T);
            }
            else
            {
                return await JsonSerializer.DeserializeAsync<T>(new MemoryStream(bytes));
            }
        }

        private async Task SetCahce<T>(long id, T result)
        {
            string key = GetKey<T>(id);
            await _distributedCache.SetAsync(key, JsonSerializer.SerializeToUtf8Bytes(result), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = new TimeSpan(0, 5, 0)
            });
        }

        private string GetKey<T>(long id)
        {
            return $"{typeof(T).Name}:Id:{id}";
        }

        private async Task DeleteCache<T>(long id)
        {
            string key = GetKey<T>(id);
            await _distributedCache.RemoveAsync(key);
        }
    }
}
