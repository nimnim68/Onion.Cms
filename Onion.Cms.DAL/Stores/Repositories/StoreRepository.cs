using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Stores.Entities;
using Onion.Cms.Domain.Stores.Repositories;

namespace Onion.Cms.DAL.Stores.Repositories
{
    public class StoreRepository : EfRepository<Store>, IStoreRepository
    {
        public StoreRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<Store> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(f=>f.Code==code);
        }

    }
}