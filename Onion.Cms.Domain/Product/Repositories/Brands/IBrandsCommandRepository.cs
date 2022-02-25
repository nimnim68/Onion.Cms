using System.Threading.Tasks;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Product.Entities;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.Domain.Product.Repositories.Brands
{
    public interface IBrandsCommandRepository : IAsyncRepository<Brand>
    {
        Task<bool> IsUniqueBrandAsync(string brand, int? brandId = null);
    }
}