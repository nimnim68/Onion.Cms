using Onion.Cms.Domain.Arrangements.Entities;
using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;

namespace Onion.Cms.Domain.Stores.Entities
{
    public class Store : BaseUserEntity<long>, IAggregateRoot
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// نوع فروشگاه
        /// </summary>
        public int StoreType { get; set; } = 1;

        /// <summary>
        /// طرح ها
        /// </summary>
        public int MembershipType { get; set; } = 1;
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string BigLogo { get; set; }
        public string SmallLogo { get; set; }

        #region RelationShip
        public Arrangement Arrangement { get; set; }

        #endregion
    }
}
