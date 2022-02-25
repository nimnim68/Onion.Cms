using System;
using System.Collections.Generic;
using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Orders.Entities;

namespace Onion.Cms.Domain.Basket.Entities
{
    public class Cart : BaseUserEntity<long>, IAggregateRoot
    {

        public Guid BrowserId { get; set; }
        public bool IsFinished { get; set; }
        public string UserIp { get; set; }
        public string BrowserName { get; set; }

        
        #region Relationship
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual Order Order { get; set; }

        #endregion

    }
}