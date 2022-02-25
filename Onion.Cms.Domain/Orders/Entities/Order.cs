using System.Collections.Generic;
using Onion.Cms.Domain.Basket.Entities;
using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Payments.Entities;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.Domain.Orders.Entities
{
    public class Order : BaseUserEntity<long>, IAggregateRoot
    {
        public long UserAddressId { get; set; }
        public OrderPostType OrderPostType { get; set; }
        public OrderState OrderState { get; set; }
        public long CartId { get; set; }

        #region  Relationship
        public virtual UserAddress UserAddress { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual Cart Cart { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        #endregion


    }
}