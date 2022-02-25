using Onion.Cms.Domain.Blogs.Dtos;
using System.Collections.Generic;
using Onion.Cms.Domain.Stores.Dtos;

namespace Onion.Cms.Web.Models
{
    public class StoreViewModel
    {
        public string SearchKey { get; set; }
        public string Title { get; set; }
        public IEnumerable<StoreDto> Stores { get; set; }
        public int TotalCount { get; set; }
    }
}
