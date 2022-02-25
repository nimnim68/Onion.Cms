using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Blogs.Commands.PostCategories
{
    public class PostCategoryCreateCommand :  IRequest<ResultDto>
    {
        public string Title { get; set; }
        public int CreatorUserId { get; set; }
    }
}