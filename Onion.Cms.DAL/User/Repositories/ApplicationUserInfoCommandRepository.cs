using System;
using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.User.Commands;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Domain.User.Repositories;

namespace Onion.Cms.DAL.User.Repositories
{
    public class ApplicationUserInfoCommandRepository : EfRepository<UserInfo>, IApplicationUserInfoCommandRepository
    {

        public ApplicationUserInfoCommandRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public void Add(UserInfo command)
        {
            DbContext.UserInfos.Add(command);
        }

        public void UpdateRep(UserInfo entity, UpdateApplicationUserInfoCommand model)
        {
            entity.Gender = model.Gender;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Birthdate = model.Birthdate;
            entity.ModifiedId = model.ModifiedId;
            entity.ModifiedDate = DateTime.Now;

        }
    }
}