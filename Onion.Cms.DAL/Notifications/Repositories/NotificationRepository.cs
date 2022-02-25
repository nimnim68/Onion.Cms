using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Notifications.Entities;
using Onion.Cms.Domain.Notifications.Repositories;
using System.Threading.Tasks;

namespace Onion.Cms.DAL.Arrangements.Repositories
{
    public class NotificationRepository : EfRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public Task MarkAsRead(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}