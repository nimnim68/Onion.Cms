using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Notifications.Queries
{
    public class NotificationUnReadCountQueries : IRequest<ResultDto<int>>
    {
    }
    
    
}