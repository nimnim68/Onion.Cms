using System.Collections.Generic;
using MediatR;
using Onion.Cms.Domain.Blogs.Commands.Posts;
using Onion.Cms.Domain.Product.Commands.Brands;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Product.Commands.Products
{
    public class PostUpdateCommand : PostCreateCommand, IRequest<ResultDto>
    {
        public long Id { get; set; }
        public int ModifierUserId { get; set; }
    }
}