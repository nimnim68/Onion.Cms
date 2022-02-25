using MediatR;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Notifications.Commands
{
    public class NotificationCreateCommand : IRequest<ResultDto>
    {
        public int TargetUserId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public NotificationType Type { get; set; }
    }
}
