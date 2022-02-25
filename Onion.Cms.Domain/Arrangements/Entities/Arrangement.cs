using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Stores.Entities;

namespace Onion.Cms.Domain.Arrangements.Entities
{
    public class Arrangement : BaseUserEntity<long>, IAggregateRoot
    {
        public long StoreId { get; set; }
        public ArrangementItems Type { get; set; }
        public DisplayPriority Priority { get; set; }
        public long? TargetId { get; set; }
        public string Description { get; set; }

        #region RelationShip

        public Store Store { get; set; }

        #endregion
    }
}
