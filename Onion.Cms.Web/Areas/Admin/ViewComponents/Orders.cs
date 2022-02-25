using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Cms.Domain.Orders.Queries;

namespace Onion.Cms.Web.Areas.Admin.ViewComponents
{
    public class Orders : ViewComponent
    {
        private readonly IMediator _mediator;

        public Orders(IMediator mediator)
        {
            _mediator = mediator;
        }
        public  IViewComponentResult Invoke()
        {
            var res =  _mediator.Send(new GetAdminOrderQueries());
            var result = res.Result;
            return View(result);
        }


    }
}
