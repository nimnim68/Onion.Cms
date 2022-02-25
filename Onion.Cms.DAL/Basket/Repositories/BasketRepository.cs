using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Basket.Entities;
using Onion.Cms.Domain.Basket.Repositories;

namespace Onion.Cms.DAL.Basket.Repositories
{
    public class BasketRepository : EfRepository<Cart>, IBasketRepository
    {
        public BasketRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task AddCartItemAsync(CartItem entity)
        {
            await DbContext.CartItems.AddAsync(entity);
        }

        public async Task AddCartItemAsync(List<CartItem> entity)
        {
            await DbContext.CartItems.AddRangeAsync(entity);
        }

        public async Task<CartItem> GetCartItemByIdAsync(long id, bool asNoTracking = false)
        {
            return await DbContext.CartItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CartItem> GetCartItemAsync(ISpecification<CartItem> spec, bool asNoTracking = false)
        {
            var dbSet = DbContext.CartItems;
            var evaluator = new SpecificationEvaluator<CartItem>();
            var specificationResult = evaluator.GetQuery(dbSet.AsQueryable(), spec);
            if (asNoTracking)
                specificationResult = specificationResult.AsNoTracking();
            return await specificationResult.FirstOrDefaultAsync();
        }

        public EntityState SoftDeleteCartItem(CartItem entity)
        {
            entity.GetType().GetProperty(nameof(entity.IsRemoved))?.SetValue(entity, true);
            entity.GetType().GetProperty(nameof(entity.RemoveTime))?.SetValue(entity, DateTime.Now);
            return DbContext.CartItems.Update(entity).State;
        }

        public void DeleteCartItem(CartItem entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        public async Task<int> CountCartItemAsync(ISpecification<CartItem> spec, bool asNoTracking = false)
        {
            var dbSet = DbContext.CartItems;
            var evaluator = new SpecificationEvaluator<CartItem>();
            var specificationResult = evaluator.GetQuery(dbSet.AsQueryable(), spec);
            if (asNoTracking)
                specificationResult = specificationResult.AsNoTracking();

            return await specificationResult.CountAsync();
        }

    }
}