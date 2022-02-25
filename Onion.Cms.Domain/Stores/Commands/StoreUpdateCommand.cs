using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Stores.Commands
{
    public class StoreUpdateCommand : StoreCreateCommand, IRequest<ResultDto>
    {
        public long Id { get; set; }
        public string Code { get; set; }
    }
}