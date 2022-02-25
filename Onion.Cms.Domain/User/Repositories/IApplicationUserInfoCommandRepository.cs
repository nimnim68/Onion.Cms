using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.User.Commands;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.Domain.User.Repositories
{
    public interface IApplicationUserInfoCommandRepository : IAsyncRepository<UserInfo>
    {
        void Add(UserInfo command);
        void UpdateRep(UserInfo entity, UpdateApplicationUserInfoCommand model);
    }
}