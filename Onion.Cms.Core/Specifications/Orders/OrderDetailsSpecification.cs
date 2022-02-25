using Ardalis.Specification;
using Onion.Cms.Domain.Orders.Entities;

namespace Onion.Cms.ApplicationServices.Specifications.Orders
{
    public sealed class OrderDetailsSpecification : Specification<OrderDetail>
    {
        public OrderDetailsSpecification(long orderId)
        {
            Query.Where(x => x.OrderId == orderId);
            Query.Include(x => x.Product).ThenInclude(x => x.ProductImages);
            Query.Include(x => x.Product).ThenInclude(x => x.Category);
            //Query.EnableCache(nameof(OrderDetailsSpecification),orderId);
        }
    }
}