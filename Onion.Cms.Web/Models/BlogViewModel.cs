using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onion.Cms.Domain.Blogs.Dtos;

namespace Onion.Cms.Web.Models
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public string SearchKey { get; set; } 
        public IEnumerable<PostCategoryListQueryDto> Categorires { get; set; }
        public IEnumerable<PostListQueryDto> Posts { get; set; }
        public int TotalCount { get; set; }
    }
}
