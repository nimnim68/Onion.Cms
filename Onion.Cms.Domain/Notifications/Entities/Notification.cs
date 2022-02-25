using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.User.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onion.Cms.Domain.Notifications.Entities
{
    public class Notification : BaseUserEntity<long>, IAggregateRoot
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }

        public int TargetUserId { get; set; }
        
        [ForeignKey(nameof(TargetUserId))]
        public virtual ApplicationUser TargetUser { get; set; }
    }
}
