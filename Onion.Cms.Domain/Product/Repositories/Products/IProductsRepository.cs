using System.Threading.Tasks;
using Onion.Cms.Domain.Interfaces;

namespace Onion.Cms.Domain.Product.Repositories.Products
{
    public interface IProductsRepository : IAsyncRepository<Entities.Product>
    {
        Task<bool> IsUniqueProductCodeAsync(string code);
    }
}