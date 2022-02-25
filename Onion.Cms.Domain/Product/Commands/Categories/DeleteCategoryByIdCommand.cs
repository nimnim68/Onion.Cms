using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Product.Commands.Categories
{
    public class DeleteCategoryByIdCommand : IRequest<ResultDto>
    {
        public long Id { get; set; }
    }
}