using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Notifications.Dtos;

namespace Onion.Cms.Domain.Notifications.Queries
{
    public class NotificationListQuery : BaseQueries, IRequest<QueryList<GetNotificationDto>>
    {
    }
    
    
}