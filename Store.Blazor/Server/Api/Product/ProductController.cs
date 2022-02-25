using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Web.Http;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Framework.Web;
using Store.Blazor.Shared.Enums;
using Store.Blazor.Shared.Models.Product;

namespace Store.Blazor.Server.Api.Product
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]

    public class ProductController : ApiBaseController<ApplicationUser>
    {
        private static ProductInfo[] _favorite;
        private static ProductInfo[] _new;
        public ProductController(UserManager<ApplicationUser> userManager, IMediator mediator) : base(userManager, mediator)
        {
            var random = new Random();
            _favorite = Enumerable.Range(1, 15).Select(x => new ProductInfo
            {
                DiscountPercent = x % 2 == 1 ? null : random.Next(0, 50),
                Price = random.Next(100000, 1000000),
                Title = $"مدل محبوب{random.Next(1, 20)}",
                Src = $"src - {random.Next(1, 20)}",
                DiscountPrice = x % 2 == 1 ? random.Next(100000, 1000000) : null

            }).ToArray();
            _new = Enumerable.Range(1, 15).Select(x => new ProductInfo
            {
                DiscountPercent = x % 2 == 1 ? null : random.Next(0, 20),
                Price = random.Next(500000, 5000000),
                Title = $"محصولات جدید{random.Next(1, 20)}",
                Src = $"src - {random.Next(1, 20)}",
                DiscountPrice = x % 2 == 1 ? random.Next(100000, 1000000) : null

            }).ToArray();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiProductListResult[]> DisplayList(int? storeId = null)
        {
            return new[] { new ApiProductListResult
            {
                Title = "محصولات محبوب",
                ProductInfo = _favorite,
                Theme = "Red"
            } ,
                new ApiProductListResult
                {
                    Title = "محصولات جدید",
                    ProductInfo = _new,
                    Theme = "Blue"
                }
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiProductListResult> List(int typeId, int page = 1, int? storeId = null)
        {
            var model = new ApiProductListResult();
            switch (typeId)
            {
                case (int)ProductType.Favorite:
                    model.Title = "محصولات محبوب";
                    model.ProductInfo = _favorite;
                    break;
                case (int)ProductType.New:
                    model.Title = "محصولات جدید";
                    model.ProductInfo = _new;
                    break;
                case 3:
                    model.Title = "جشنواره";
                    break;
            }

            return model;
        }


    }






}
