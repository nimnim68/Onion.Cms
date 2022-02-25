using System;
using System.Collections.Generic;
using MediatR;
using Onion.Cms.Domain.Blogs.Commands.Posts;
using Onion.Cms.Domain.Product.Commands.Brands;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Blogs.Commands.PostCategories
{
    public class PostCategoryUpdateCommand :IRequest<ResultDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ModifierUserId { get; set; }
        
    }
}