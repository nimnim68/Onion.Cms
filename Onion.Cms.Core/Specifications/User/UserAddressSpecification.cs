using Ardalis.Specification;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.ApplicationServices.Specifications.User
{
    public sealed class UserAddressSpecification : Specification<UserAddress>
    {
        public UserAddressSpecification(int userId)
        {
            Query.Where(x => x.ApplicationUserId == userId && x.IsRemoved == false).Include(x => x.District)
                .ThenInclude(x => x.Province).ThenInclude(x => x.Zone);
        }
    }
}