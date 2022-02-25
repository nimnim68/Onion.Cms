﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onion.Cms.Framework.Web;

namespace Onion.Cms.Web.Areas.Panel.Controllers
{
    [Area(nameof(Panel))]
    [Route("[area]/[controller]/[action]")]
    public class WalletController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
