using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;

namespace Onion.Cms.Domain.Orders.Entities
{
    public  class OrderDetail : BaseUserEntity<long>, IAggregateRoot
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        public decimal FinalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Price { get; set; }
        
        public int Count { get; set; }
        
        #region  Relationship

        public virtual Order Order { get; set; }      
        public virtual Product.Entities.Product Product { get; set; }      
        
        #endregion
    }
}