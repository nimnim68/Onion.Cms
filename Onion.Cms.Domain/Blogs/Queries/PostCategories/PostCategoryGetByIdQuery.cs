using MediatR;
using Onion.Cms.Domain.Blogs.Dtos;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Blogs.Queries.PostCategories
{
    public class PostCategoryGetByIdQuery : IRequest<ResultDto<PostCategoryGetQueryDto>>
    {
        public long Id { get; set; }
}
}
