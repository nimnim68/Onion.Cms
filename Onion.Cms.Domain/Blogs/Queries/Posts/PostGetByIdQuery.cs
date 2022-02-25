using MediatR;
using Onion.Cms.Domain.Blogs.Dtos;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Blogs.Queries.Posts
{
    public class PostGetByIdQuery: IRequest<ResultDto<PostGetQueryDto>>
    {
        public long Id { get; set; }
}
}
