using System.ComponentModel.DataAnnotations.Schema;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Framework.Domain;

namespace Onion.Cms.Domain.Common
{
    public class BaseUserEntity<T> : BaseEntity<T>
    {
        [ForeignKey(nameof(CreatorUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
