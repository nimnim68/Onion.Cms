using MediatR;
using Onion.Cms.Domain.Blogs.Dtos;
using Onion.Cms.Domain.DTOs;

namespace Onion.Cms.Domain.Blogs.Queries.Posts
{
    public class PostPaginationQueries : BaseQueries, IRequest<QueryList<PostListQueryDto>>
    {
        public int? CategoryId { get; set; }
    }
}
