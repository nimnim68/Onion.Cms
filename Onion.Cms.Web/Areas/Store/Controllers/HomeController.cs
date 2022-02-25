using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Cms.Domain.Stores.Dtos;
using Onion.Cms.Domain.Stores.Queries;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Web.Areas.Store.Models;
using Onion.Cms.Web.Common;
using System.Threading.Tasks;

namespace Onion.Cms.Web.Areas.Store.Controllers
{
    [Area(Const.Area.Store)]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Store/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            ResultDto<StoreDto> result ;
            if (int.TryParse(id, out var storeId))
            {
                result = await _mediator.Send(new StoreGetByIdQuery() { Id = storeId });
            }
            else
            {
                result = await _mediator.Send(new StoreGetByCodeQuery { Code = id });
            }
            return View(new FirstPageViewModel { Store = result.Data });
        }
    }
}
