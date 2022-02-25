using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Onion.Cms.Domain.Basket.Commands;
using Onion.Cms.Domain.Basket.Queries;
using Onion.Cms.Domain.DTOs.Site.Products;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.Orders.Commands;
using Onion.Cms.Domain.Orders.Dtos;
using Onion.Cms.Domain.Orders.Queries;
using Onion.Cms.Domain.Payments.Commands;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Domain.User.Queries;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Rest;
using Onion.Cms.Framework.Web;
using Onion.Cms.Framework.Zarinpal;
using Onion.Cms.Web.Common;
using Onion.Cms.Web.Models;

namespace Onion.Cms.Web.Controllers
{
    public class CartController : BaseController<ApplicationUser>
    {
        private readonly CookiesManager _cookies;
        private readonly string _merchant;
        public CartController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator, userManager)
        {
            _cookies = new CookiesManager();
            _merchant = "43159e03-7b7b-4175-9cc5-5ea5fe546435";
        }
        public async Task<IActionResult> Index()
        {
            var browserId = _cookies.GetBrowserId(HttpContext);
            var userId = (await CurrentUser())?.Id;
            var myCart = await Mediator.Send(new GetCardQueries()
            {
                BrowserId = browserId,
                UserId = userId

            });
            return View(myCart.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(ResultProductDetailsSiteDto model)
        {
            var res = await AddCard(model.ProductAddToCart.ProductId, model.ProductAddToCart.Count);
            if (res.IsSuccess)
                return RedirectToAction(nameof(Index));
            return RedirectToAction(actionName: "Index", controllerName: "Product");
        }

        private async Task<ResultDto> AddCard(long productId, int count = 1)
        {
            var browserId = _cookies.GetBrowserId(HttpContext);
            var userId = (await CurrentUser())?.Id;
            var ip = "";
            var userAgent = Request.Headers?.FirstOrDefault(s => s.Key.ToLower() == "user-agent").Value;

            if (HttpContext.Connection.RemoteIpAddress != null) 
                ip = HttpContext.Connection.RemoteIpAddress.ToString();

            var res = await Mediator.Send(new AddCartCommand
            {
                BrowserId = browserId,
                ProductId = productId,
                Count = count,
                UserId = userId,
                UserIp = ip,
                BrowserName = userAgent
            });
            return res;
        }

        public async Task<IActionResult> AddToBasket(long id)
        {
            var res = await AddCard(id);
            if (res.IsSuccess)
                return RedirectToAction(nameof(Index));
            return RedirectToAction(actionName: "Index", controllerName: "Product");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCartItem(long id, int count)
        {
            var browserId = _cookies.GetBrowserId(HttpContext);
            var userId = (await CurrentUser())?.Id;
            var res = await Mediator.Send(new UpdateCountCartCommand { BrowserId = browserId, CartItemId = id, Count = count, UserId = userId });
            return Json(res);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveCartItem(long id)
        {
            var browserId = _cookies.GetBrowserId(HttpContext);
            var userId = (await CurrentUser())?.Id;
            var res = await Mediator.Send(new RemoveFromCardCommand { BrowserId = browserId, CartItemId = id, UserId = userId });
            return Json(res);
        }

        [Route("shipping")]
        [Authorize]
        public async Task<IActionResult> Shipping()
        {
            var browserId = _cookies.GetBrowserId(HttpContext);
            var userId = (await CurrentUser())?.Id;
            var address = await Mediator.Send(new GetUserAddressQueries
            { ApplicationUserId = userId.GetValueOrDefault() });

            var request = await Mediator.Send(new GetCardShippingQueries
            {
                BrowserId = browserId,
                UserId = userId
            });
            var model = new ShippingViewModel
            {
                CartPayDto = request.Data,
                UserAddressDtos = address
            };
            return View(model);
        }

        [Route("shipping")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Shipping(ShippingViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await CurrentUser();
            var userId = user?.Id;
            var res = await Mediator.Send(new AddOrderCommand
            {
                CreatorUserId = userId,
                OrderState = OrderState.Processing,
                OrderPostType = model.OrderPostType,
                UserAddressId = model.UserAddressId
            });
            if (res.IsSuccess)
            {
                if (model.PaymentType == PaymentType.Online)
                {
                    var callbackUrl = "https://www.shirjat.ir/Payment/" + res.Data.Id;
                    var zarinpalUrl = "https://zarinpal.com";
#if DEBUG
                    callbackUrl = "https://localhost:5001/Payment/" + res.Data.Id;
                    zarinpalUrl = "https://sandbox.zarinpal.com";
#endif
                    var request = new ZarinpalModel.Payment.Request
                    {
                        MerchantId = _merchant,
                        Amount = res.Data.Amount,
                        Description = $"پرداخت شماره فاکتور {res.Data.Id}",
                        CallbackUrl = callbackUrl
                    };
                    var response = ZarinPalRestApi.PaymentRequest(request);
                    if (response.Status == 100)
                        return Redirect($"{zarinpalUrl}/pg/StartPay/{response.Authority}");
                }
                else
                {
                    var payRes = await Mediator.Send(new AddPaymentCommand()
                    {
                        CreatorUserId = userId,
                        RefId = 0,
                        Authority = null,
                        Amount = res.Data.Amount,
                        IsPay = false,
                        PayDate = null,
                        IsRemoved = false,
                        OrderId = res.Data.Id,
                        PaymentType = model.PaymentType

                    });
                    if (payRes.IsSuccess)
                    {
                        var sms = SendSms((await CurrentUser()).PhoneNumber);
                        return View("PaymentResult", new PaymentResultDto { PaymentType = model.PaymentType, IsPay = false, Factor = res.Data.Id.ToString() });
                    }
                }
            }
            return View(model);
        }

        [Route("payment/{factorId}")]
        [Authorize]
        public async Task<IActionResult> Payment(long factorId, string authority, string status)
        {
            var user = await CurrentUser();
            var userId = user?.Id;
            var model = new PaymentResultDto
            {
                PaymentType = PaymentType.Online,
                IsPay = false,
                Factor = factorId.ToString()
            };
            try
            {
                var amount = await Mediator.Send(new GetOrderByIdQueries { OrderId = factorId });
                var paymentCommand = new AddPaymentCommand
                {
                    CreatorUserId = userId,
                    RefId = 0,
                    Authority = authority,
                    Amount = amount.Amount,
                    IsPay = false,
                    PayDate = null,
                    IsRemoved = false,
                    OrderId = factorId,
                    PaymentType = PaymentType.Online,
                    StatusCode = status,
                    StatusCodeMessage = PaymentResult.ZarinPal(status),

                };
                switch (status.ToUpper())
                {
                    case "NOK":
                        model.IsPay = false;
                        model.Message = PaymentResult.ZarinPal(status);

                        await Mediator.Send(new UpdateCartFinished { CartId = factorId });
                        break;
                    case "OK":
                    {
                        var request = new ZarinpalModel.PaymentVerification.Request
                        {
                            MerchantId = _merchant,
                            Authority = authority,
                            Amount = amount.Amount
                        };
                        var response = ZarinPalRestApi.PaymentVerification(request);
                        if (response.Status == 100)
                        {
                            model.IsPay = true;
                            model.RefId = response.RefId;

                            paymentCommand.IsPay = true;
                            paymentCommand.PayDate = DateTime.Now;
                            paymentCommand.RefId = response.RefId;
                            paymentCommand.StatusCode = response.Status.ToString();
                            paymentCommand.StatusCodeMessage = PaymentResult.ZarinPal(response.Status.ToString());

                            var sms = SendSms((await CurrentUser()).PhoneNumber);

                        }
                        else
                        {
                            model.IsPay = false;
                            model.Message = PaymentResult.ZarinPal(response.Status.ToString());
                            paymentCommand.StatusCode = response.Status.ToString();
                            paymentCommand.StatusCodeMessage = PaymentResult.ZarinPal(response.Status.ToString());
                        }

                        break;
                    }
                }
                var payRes = await Mediator.Send(paymentCommand);
                if (!payRes.IsSuccess)
                {
                    model.IsPay = false;
                    await Mediator.Send(new UpdateCartFinished { CartId = factorId });
                }
            }
            catch (Exception e)
            {
                model.Message = "پاسخی از درگاه پرداخت دریافت نشده";
            }
            return View("PaymentResult", model);
        }

        private bool SendSms(string to)
        {
            var sms = new FarazSmsService("09126035402", "0011062991", "+98500010706035402");
            return sms.SendSms("سلام خوبی", to);
        }
    }
}
