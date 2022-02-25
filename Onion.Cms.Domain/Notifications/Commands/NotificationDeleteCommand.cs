using MediatR;
using Onion.Cms.Framework.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Cms.Domain.Notifications.Commands
{
    public class NotificationDeleteCommand : IRequest<ResultDto>
    {
        public long Id { get; set; }
        public bool IsSoftDelete { get; set; }
    }
}
