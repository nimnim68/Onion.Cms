using System.Collections.Generic;
using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;

namespace Onion.Cms.Domain.Product.Entities
{
    public class Category : BaseUserEntity<long>, IAggregateRoot
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
        public string Icon { get; set; }

        #region Relationships
        public ICollection<Category> Children { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual Category Parent { get; set; }

        #endregion
    }
}