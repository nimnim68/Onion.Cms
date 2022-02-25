using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Orders.Entities;
using Onion.Cms.Domain.Orders.Repositories;

namespace Onion.Cms.DAL.Orders.Repositories
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}