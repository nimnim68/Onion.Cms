using System;
using MediatR;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.User.Commands
{
    public class UpdateApplicationUserInfoCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Gender { get; set; }
    }
}