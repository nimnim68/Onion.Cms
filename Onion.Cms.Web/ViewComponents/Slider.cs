using Microsoft.AspNetCore.Mvc;
using Onion.Cms.ApplicationServices.Services.Interface;
using System.Threading.Tasks;
using MediatR;
using Onion.Cms.Domain.Slider.Queries;

namespace Onion.Cms.Web.ViewComponents
{
    [ViewComponent(Name = "Slider")]
    public class Slider : ViewComponent
    {
        private readonly IMediator _mediator;

        public Slider(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IViewComponentResult Invoke()
        {
            var res = _mediator.Send(new SliderPaginationQueries() { PageSize = 4, Skip = 0 }).Result;
            return View("Slider", res.Data);
        }
    }
}
