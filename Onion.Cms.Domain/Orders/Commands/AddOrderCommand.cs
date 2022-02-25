using MediatR;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.Orders.Dtos;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Orders.Commands
{
    public class AddOrderCommand : BaseCommandEntity,  IRequest<ResultDto<OrderDto>>
    {
        public long UserAddressId { get; set; }
        public OrderPostType OrderPostType { get; set; }
        public OrderState OrderState { get; set; }
    }


}