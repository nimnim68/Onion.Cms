using System.Collections.Generic;
using Onion.Cms.Framework.Domain;

namespace Onion.Cms.Domain.Zone.Entities
{
    public class Zone : BaseHcEntity<long>
    {

        #region Relations
        public ICollection<Province> Province { get; set; }
        #endregion
    }
}