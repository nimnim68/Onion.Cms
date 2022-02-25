using MediatR;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Blogs.Commands.Posts
{
    public class PostDeleteCommand : IRequest<ResultDto>
    {
        public long Id { get; set; }
        public bool IsSoftDelete { get; set; } = false;
        public int ModifierUserId { get; set; }
    }
}