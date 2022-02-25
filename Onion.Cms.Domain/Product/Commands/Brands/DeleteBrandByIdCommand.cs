using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Product.Commands.Brands
{
    public class DeleteBrandByIdCommand : IRequest<ResultDto>
    {
        public int Id { get; set; }
        public bool IsSoftDelete { get; set; } = false;
        public int ModifiedId { get; set; }
    }
}