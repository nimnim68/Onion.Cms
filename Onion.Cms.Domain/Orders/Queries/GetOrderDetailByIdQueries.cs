using MediatR;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Orders.Dtos;

namespace Onion.Cms.Domain.Orders.Queries
{
    public class GetOrderByIdQueries : IRequest<OrderDto>
    {
        public long OrderId { get; set; }
    }
    public class GetOrderByUserIdQueries : BaseQueries, IRequest<QueryList<OrderDto>>
    {
        public int UserId { get; set; }
    }
    public class GetOrderDetailsQueries : BaseQueries, IRequest<QueryList<OrderDetailsDto>>
    {
        public long OrderId { get; set; }
    }
    public class GetAdminOrderQueries : BaseQueries, IRequest<QueryList<AdminOrderDto>>
    {
        
    }
    public class GetAdminOrderDetailsQueries : BaseQueries, IRequest<OrderDetailsAdminDto>
    {
        public long OrderId { get; set; }
    }
}