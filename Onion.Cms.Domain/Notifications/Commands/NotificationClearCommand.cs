using MediatR;
using Onion.Cms.Framework.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Cms.Domain.Notifications.Commands
{
    public class NotificationClearCommand : IRequest<ResultDto>
    {
        public long TargetUserId { get; set; }
        public bool IsSoftDelete { get; set; }
    }
}
