using System;
using System.Linq.Expressions;
using Ardalis.Specification;
using JetBrains.Annotations;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.Stores.Entities;

namespace Onion.Cms.ApplicationServices.Specifications.Stores
{
    public sealed class StoreSpecification : Specification<Store>
    {
        public StoreSpecification(string searchKey, [CanBeNull] Expression<Func<Store, object>> filter = null, OrderType sortDirection = OrderType.Ascending)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                Query.Where(m => m.Title.Contains(searchKey));
            }

            if (filter != null)
            {
                if (sortDirection == OrderType.Ascending)
                {
                    Query.OrderBy(filter!);
                }
                else if (sortDirection == OrderType.Descending)
                {
                    Query.OrderByDescending(filter);
                }
            }
        }
    }
}