using System.Security;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Stores.Entities;
using System.Threading.Tasks;

namespace Onion.Cms.Domain.Stores.Repositories
{
    public interface IStoreRepository : IAsyncRepository<Store>
    {
        Task<Store> GetByCodeAsync(string code);
    }
}