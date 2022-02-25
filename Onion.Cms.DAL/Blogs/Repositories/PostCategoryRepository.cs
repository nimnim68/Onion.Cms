using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Blogs.Entities;
using Onion.Cms.Domain.Blogs.Repositories;
using Onion.Cms.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Cms.DAL.Blogs.Repositories
{
    public class PostCategoryRepository : EfRepository<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IReadOnlyList<PostCategory>> ListAllAsync(bool asNoTracking = false)
        {
            var rep = await _dbSet.AsNoTracking().ToListAsync();
            return rep;
        }

        public override async Task<IReadOnlyList<PostCategory>> GetPagedRespondAsync(ISpecification<PostCategory> spec, int pageSize = 10, int skip = 0, int? pageNumber = null, bool asNoTracking = true)
        {
            if (pageNumber.HasValue)
                skip = (pageNumber.Value - 1) * pageSize;
            if (pageSize == 0)
                pageSize = 10;
            var specificationResult = ApplySpecification(spec).Skip(skip)
                .Take(pageSize);
            if (asNoTracking)
                specificationResult = specificationResult.AsNoTracking();
            return await specificationResult.ToListAsync();
        }



        IQueryable<PostCategory> IAsyncRepository<PostCategory>.RawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<PostCategory>> IAsyncRepository<PostCategory>.GetPagedRespondAsync(int pageSize, int skip, int? pageNumber)
        {
            throw new NotImplementedException();
        }


    }
}