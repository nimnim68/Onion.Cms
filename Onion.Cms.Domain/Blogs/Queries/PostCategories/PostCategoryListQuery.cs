using MediatR;
using Onion.Cms.Domain.Blogs.Dtos;
using Onion.Cms.Domain.DTOs;

namespace Onion.Cms.Domain.Blogs.Queries.PostCategories
{
    public class PostCategoryListQuery : BaseQueries, IRequest<QueryList<PostCategoryListQueryDto>>
    {
    }
}
