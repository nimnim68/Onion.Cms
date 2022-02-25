using MediatR;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Product.Commands.Categories
{
    public class CategoryCreateCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
        public string Icon { get; set; }
    }
    public class CategoryUpdateCommand : CategoryCreateCommand
    {
        public long Id { get; set; }
    }
}