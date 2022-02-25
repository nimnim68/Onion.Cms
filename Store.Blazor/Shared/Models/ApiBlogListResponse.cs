using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Blazor.Shared.Models
{
    public class ApiBlogListResponse
    {
        public IReadOnlyList<PostInfo> Post { get; set; }
        public int Total { get; set; }

    }

    public class PostInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public int UserTitle { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}