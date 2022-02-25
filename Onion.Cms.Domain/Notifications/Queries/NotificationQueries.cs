using System.Collections.Generic;
using MediatR;
using Onion.Cms.Domain.Notifications.Dtos;

namespace Onion.Cms.Domain.Notifications.Queries
{
    public class NotificationQueries : IRequest<IReadOnlyList<GetNotificationDto>>
    {
        
    }   
}