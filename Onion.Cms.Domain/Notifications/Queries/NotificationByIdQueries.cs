using MediatR;
using Onion.Cms.Domain.Notifications.Dtos;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Notifications.Queries
{
    public class NotificationByIdQueries : IRequest<ResultDto<GetNotificationDto>>
    {
        public long Id { get; set; }
    }
    
    
}