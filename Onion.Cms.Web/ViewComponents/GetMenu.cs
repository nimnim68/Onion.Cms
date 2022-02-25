using Microsoft.AspNetCore.Mvc;
using Onion.Cms.ApplicationServices.Services;
using Onion.Cms.ApplicationServices.Services.Interface;

namespace Onion.Cms.Web.ViewComponents
{
    [ViewComponent(Name = "GetMenu")]
    public class GetMenu : ViewComponent
    {
        private readonly IMenuService _menuService;

        public GetMenu(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IViewComponentResult Invoke()
        {
            var res =  _menuService.GetMenuAsync().Result;
            return View("GetMenu", res.Data);
        }
    }
}
