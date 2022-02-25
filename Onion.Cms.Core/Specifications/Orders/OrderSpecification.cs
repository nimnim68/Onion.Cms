using Ardalis.Specification;
using Onion.Cms.Domain.Orders.Entities;

namespace Onion.Cms.ApplicationServices.Specifications.Orders
{
    public sealed class OrderSpecification : Specification<Order>
    {
        public OrderSpecification(long id)
        {
            Query.Where(x => x.Id == id).Include(x => x.OrderDetails);
        }
        public OrderSpecification(long? cartId)
        {
            Query.Where(x => x.CartId == cartId).Include(x => x.OrderDetails);
        }

        public OrderSpecification(int userId)
        {
            Query.OrderByDescending(x => x.Id);
            Query.Where(x => x.CreatorUserId == userId).Include(x => x.OrderDetails);
        }
        public OrderSpecification()
        {
            Query.Where(x => !x.IsRemoved).OrderByDescending(x => x.Id);
            Query.Include(x => x.Payments);
            Query.OrderByDescending(x => x.CreateDate).ThenBy(x => x.OrderState);
        }
        public OrderSpecification(long orderId, bool isAdmin)
        {
            Query.Where(x => x.Id == orderId).Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Category);
            Query.Where(x => x.Id == orderId).Include(x => x.ApplicationUser).ThenInclude(x => x.UserInfo);
            Query.Include(x => x.UserAddress);
        }
    }
}