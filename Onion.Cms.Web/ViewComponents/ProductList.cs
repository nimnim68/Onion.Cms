using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.Product.Queries.Products;
using Onion.Cms.Framework.Helper;
using Onion.Cms.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Cms.Web.ViewComponents
{
    public class InvokeRequest
    {
        public ArrangementItems Type { get; set; }
        public long StoreId { get; set; }
        public long? TargetId { get; set; }
    }

    [ViewComponent(Name = "ProductList")]
    public class ProductList : ViewComponent
    {
        private readonly IMediator _mediator;
        Dictionary<ArrangementItems, (Ordering ordering, string view)> dic = new Dictionary<ArrangementItems, (Ordering ordering, string view)> {
        { ArrangementItems.ProductSmallFavorite,(Ordering.MostPopular,"small")},
        { ArrangementItems.ProductSmallMoreSell,(Ordering.BestSelling,"small")},
        { ArrangementItems.ProductSmallMoreView,(Ordering.MostVisited,"small")},
        { ArrangementItems.ProductSmallNew,(Ordering.TheNewest,"small")},
        { ArrangementItems.ProductSmallOff,(Ordering.MostOffer,"small")},
        { ArrangementItems.ProductBigFavorite,(Ordering.MostPopular,"big")},
        { ArrangementItems.ProductBigMoreSell,(Ordering.BestSelling,"big")},
        { ArrangementItems.ProductBigMoreView,(Ordering.MostVisited,"big")},
        { ArrangementItems.ProductBigNew,(Ordering.TheNewest,"big")},
        { ArrangementItems.ProductBigOff,(Ordering.MostOffer,"big")},

    };
        public ProductList(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(InvokeRequest request)
        {
            var info = dic[request.Type];
            var result = await _mediator.Send(new GetProductQueries
            {
                Ordering = info.ordering,
            });

            return View(info.view, new ProductListViewModel(result, EnumHelper<Ordering>.GetDisplayValue(info.ordering)));
        }
    }
}
