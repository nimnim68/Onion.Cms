using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Orders.Entities;
using Onion.Cms.Domain.Orders.Repositories;

namespace Onion.Cms.DAL.Orders.Repositories
{
    public class OrderDetailRepository : EfRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}