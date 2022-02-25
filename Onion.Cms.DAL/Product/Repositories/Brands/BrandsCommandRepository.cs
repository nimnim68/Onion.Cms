using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Product.Entities;
using Onion.Cms.Domain.Product.Repositories.Brands;

namespace Onion.Cms.DAL.Product.Repositories.Brands
{
    public class BrandsCommandRepository : EfRepository<Brand>, IBrandsCommandRepository
    {
        public BrandsCommandRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsUniqueBrandAsync(string brand, int? brandId = null)
        {
            if (brandId.HasValue)
            {
                return await DbContext.Brands.AnyAsync(x => x.Id != brandId && x.Title.ToLower() == brand.ToLower());
            }
            return await DbContext.Brands.AnyAsync(x => x.Title.ToLower() == brand.ToLower());
        }
    }
}