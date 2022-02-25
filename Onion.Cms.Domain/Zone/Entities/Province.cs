using System.Collections.Generic;
using Onion.Cms.Framework.Domain;

namespace Onion.Cms.Domain.Zone.Entities
{
    public class Province : BaseHcEntity<long>
    {
        public long ZoneId { get; set; }

        #region Relations
        public virtual Zone Zone { get; set; }
        public ICollection<District> District { get; set; }
        #endregion

    }
}