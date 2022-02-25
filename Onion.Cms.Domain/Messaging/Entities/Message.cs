using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onion.Cms.Domain.Chats.Entities
{
    public class Message : BaseUserEntity<long>, IAggregateRoot
    {
        public string Content { get; set; }
        public long MessageId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual MessageCategory Category { get; set; }

        //[ForeignKey(nameof(MessageId))]
        //public virtual Message Replied { get; set; }

        //public virtual ICollection<Message> Replies { get; set; }
    }
}
