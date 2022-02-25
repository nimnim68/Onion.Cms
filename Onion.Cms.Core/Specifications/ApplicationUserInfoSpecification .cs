using Ardalis.Specification;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.ApplicationServices.Specifications
{
    public sealed class ApplicationUserInfoSpecification : Specification<UserInfo>
    {
        public ApplicationUserInfoSpecification(int applicationUserId)
        {
            Query.Where(x => x.ApplicationUserId == applicationUserId);
        }
    }
}