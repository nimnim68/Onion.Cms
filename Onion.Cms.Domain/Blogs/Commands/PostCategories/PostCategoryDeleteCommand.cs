using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Blogs.Commands.PostCategories
{
    public class PostCategoryDeleteCommand : IRequest<ResultDto>
    {
        public int Id { get; set; }
        public int ModifierUserId { get; set; }
    }
}