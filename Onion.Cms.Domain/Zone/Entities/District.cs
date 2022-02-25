using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Framework.Domain;

namespace Onion.Cms.Domain.Zone.Entities
{
    public class District : BaseHcEntity<long>
    {
        public long ProvinceId { get; set; }

        #region relations
        public virtual Province Province { get; set; }
        public virtual UserAddress ApplicationUserAddress { get; set; }
        #endregion
    }
}