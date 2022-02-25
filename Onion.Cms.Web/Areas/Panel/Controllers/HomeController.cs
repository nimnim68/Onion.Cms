using Microsoft.AspNetCore.Mvc;
using Onion.Cms.Web.Common;

namespace Onion.Cms.Web.Areas.Panel.Controllers
{
    [Area(Const.Area.Panel)]
    //[Route("[area]/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
