using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;

namespace Onion.Cms.Domain.SMS.Entities
{
    public class SMS : BaseUserEntity<long>, IAggregateRoot
    {
        public string Receiver { get; set; }
        public string Message { get; set; }
    }
}