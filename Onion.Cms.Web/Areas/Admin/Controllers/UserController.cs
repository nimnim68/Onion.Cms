using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onion.Cms.Domain.User.Dtos;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Web.Common;
using SHPA.Common.Extension;
using System;
using System.Linq;
using System.Threading.Tasks;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Resources.Interface;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Web.Areas.Admin.Controllers
{
    [Area(Const.Area.Admin)]
    [Authorize(Roles = Const.Roles.Admin)]
    public class UserController : BaseController<ApplicationUser>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IResourceManager _resourceManager;
        public UserController(IMediator mediator, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IResourceManager resourceManager) : base(mediator, userManager)
        {
            _roleManager = roleManager;
            _resourceManager = resourceManager;
        }
        public async Task<IActionResult> Index()
        {

            var user = UserManager.Users.Select(x => new UserDto
            {
                RegisterDate = x.RegisteredDate.GetValueOrDefault().EnglishToPersian("$yyyy/$MM/$dd"),
                Id = x.Id,
                Email = x.Email,
            }).ToList();

            foreach (var us in user)
            {
                us.Roles = (await UserManager.GetRolesAsync(UserManager.Users.FirstOrDefault(x => x.Id == us.Id))).ToList();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            var roles = _roleManager.Roles.ToSelectItemList(e => e.Description, e => e.Id);
            var model = new AddUserDto()
            {
                Roles = roles
            };
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AddUserDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                RegisteredDate = DateTime.Now,

            };
            var res = await UserManager.CreateAsync(user, model.Password);

            if (res.Succeeded)
            {
                var roles = await _roleManager.Roles.Where(x => model.RoleIds.Contains(x.Id)).Select(x => x.Name).ToListAsync();
                var rolRes = await UserManager.AddToRolesAsync(user, roles);
                if (rolRes.Succeeded)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<JsonResult> Delete(int id)
        {
            var resultDto = new ResultDto(_resourceManager);

            try
            {
                var usr = await CurrentUser();
                var user = await UserManager.Users.SingleOrDefaultAsync(x => x.Id == id);

                if (usr.Id != id)
                {
                    var rolesForUser = await UserManager.GetRolesAsync(user);
                    var result = IdentityResult.Success;
                    foreach (var item in rolesForUser)
                    {
                        result = await UserManager.RemoveFromRoleAsync(user, item);
                        if (result != IdentityResult.Success)
                            break;
                    }
                    if (result == IdentityResult.Success)
                    {
                        result = await UserManager.DeleteAsync(user);
                        if (!result.Succeeded)
                        {
                            foreach (var itemError in result.Errors)
                                resultDto.Message += itemError + "\n";
                            resultDto.IsSuccess = false;
                        }
                        resultDto.Message = _resourceManager[SharedResource.DeleteMessage];
                    }
                }
                else
                {
                    resultDto.IsSuccess = false;
                    resultDto.Message = "اجازه حذف خود را ندارید";
                }
            }
            catch (Exception e)
            {
                resultDto.Message = _resourceManager[SharedResource.SaveError]; ;
                resultDto.IsSuccess = false;
                resultDto.AddError(SharedResource.SaveError);
            }
            return Json(resultDto);
        }
    }
}
