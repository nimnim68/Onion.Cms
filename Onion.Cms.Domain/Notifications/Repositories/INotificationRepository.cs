using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Notifications.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Cms.Domain.Notifications.Repositories
{
    public interface INotificationRepository : IAsyncRepository<Notification>
    {
        Task MarkAsRead(long id);
    }
}
