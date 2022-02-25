using MediatR;
using Onion.Cms.Domain.User.Dtos;

namespace Onion.Cms.Domain.User.Queries
{
    public class GetApplicationUserInfoQuery : IRequest<ApplicationUserInfoDto>
    {
        public int ApplicationUserId { get; set; }
    }
}