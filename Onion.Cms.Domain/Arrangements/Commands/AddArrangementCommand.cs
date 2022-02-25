using MediatR;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Arrangements.Commands
{
    public class AddArrangementCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public long StoreId { get; set; }
        public ArrangementItems Type { get; set; }
        public DisplayPriority Priority { get; set; }
        public long? TargetId { get; set; }
        public string Description { get; set; }
    }
}