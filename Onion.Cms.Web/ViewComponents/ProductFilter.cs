using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Cms.Domain.DTOs.Site.Products;
using Onion.Cms.Domain.Product.Queries.Brands;
using Onion.Cms.Domain.Product.Queries.Categories;

namespace Onion.Cms.Web.ViewComponents
{
    [ViewComponent(Name = "ProductFilter")]
    public class ProductFilter : ViewComponent
    {
        private readonly IMediator _mediator;

        public ProductFilter(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _mediator.Send(new GetCategoryQueries());
            var brands = await _mediator.Send(new GetBrandQueries { PageSize = 1000 });

            var filters = new ProductFilters()
            {
                Brands = brands,
                Categories = categories
            };

            return View(filters);
        }
    }
}