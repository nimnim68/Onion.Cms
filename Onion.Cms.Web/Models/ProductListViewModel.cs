using Onion.Cms.Domain.DTOs.Site.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Cms.Web.Models
{
    public class ProductListViewModel: ResultProductSiteDto
    {
        public ProductListViewModel(ResultProductSiteDto data,string title)
        {
            Products = data.Products;
            TotalRow = data.TotalRow;
            Title = title;
        }
        public string Title { get;  }
    }
}
