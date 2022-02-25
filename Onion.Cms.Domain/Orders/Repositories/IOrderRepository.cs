using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.Orders.Entities;

namespace Onion.Cms.Domain.Orders.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        
    }
}