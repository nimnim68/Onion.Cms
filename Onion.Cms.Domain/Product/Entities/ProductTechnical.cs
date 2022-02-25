using Onion.Cms.Domain.Common;

namespace Onion.Cms.Domain.Product.Entities
{
    public class ProductTechnical : BaseUserEntity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long ProductId { get; set; }

        #region Relationships
        public virtual Product Product { get; set; }

        #endregion
    }
}