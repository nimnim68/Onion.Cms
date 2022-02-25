using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Product.Commands.Products
{
    public class DeleteProductCommand : IRequest<ResultDto>
    {
        public long Id { get; set; }
    }
}