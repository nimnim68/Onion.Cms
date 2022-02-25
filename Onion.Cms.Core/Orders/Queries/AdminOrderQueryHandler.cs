using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Onion.Cms.ApplicationServices.Specifications.Orders;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Orders.Dtos;
using Onion.Cms.Domain.Orders.Entities;
using Onion.Cms.Domain.Orders.Queries;
using Onion.Cms.Domain.Orders.Repositories;
using Onion.Cms.Framework.Common;

namespace Onion.Cms.ApplicationServices.Orders.Queries
{
    public class AdminOrderQueryHandler : IRequestHandler<GetAdminOrderQueries, QueryList<AdminOrderDto>>
    {
        private readonly IOrderRepository _repository;

        public AdminOrderQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<QueryList<AdminOrderDto>> Handle(GetAdminOrderQueries request, CancellationToken cancellationToken)
        {
            var spec = new OrderSpecification();
            var count = await _repository.CountAsync(spec);
            var res = await _repository.GetPagedRespondAsync(spec, request.PageSize, request.Skip);
            var lst = res?.Select(Mapper).ToList().AsReadOnly();
            return new QueryList<AdminOrderDto> { Data = lst, TotalCount = count };
        }

        private AdminOrderDto Mapper(Order order)
        {
            var payment = order.Payments.LastOrDefault(x => !x.IsRemoved);
            return new AdminOrderDto
            {
                Id = order.Id,
                CreatorUserId = order.CreatorUserId,
                CreateDate = order.CreateDate,
                ModifiedId = order.ModifiedId,
                ModifiedDate = order.ModifiedDate,
                RemoveTime = order.RemoveTime,
                OrderDate = order.CreateDate,
                Amount = payment?.Amount ?? 0,
                OrderState = order.OrderState.GetEnumDisplayName(),
                OrderId = order.Id,
                IsPay = payment?.IsPay,
                PayableAmount = payment?.IsPay == false ? payment.Amount : 0,
            };
        }
    }
}