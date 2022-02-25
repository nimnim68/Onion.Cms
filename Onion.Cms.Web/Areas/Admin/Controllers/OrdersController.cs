using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Onion.Cms.Domain.Orders.Queries;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Framework.Common.Interfaces;
using Onion.Cms.Web.Common;

namespace Onion.Cms.Web.Areas.Admin.Controllers
{
    [Area(Const.Area.Admin)]
    [Authorize]
    public class OrdersController : BaseController<ApplicationUser>
    {
        private readonly IFileHandler _fileHandler;
        public OrdersController(IMediator mediator,
            UserManager<ApplicationUser> userManager,
            IFileHandler fileHandler) : base(mediator, userManager)
        {
            _fileHandler = fileHandler;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Invoice(long id)
        {
            var result = await Mediator.Send(new GetAdminOrderDetailsQueries() { OrderId = id });
            return View(result);
        }

    }
}
