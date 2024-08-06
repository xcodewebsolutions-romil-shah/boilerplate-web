using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Boilerplate.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Boilerplate.Infrastructure.Contracts;

namespace Boilerplate.Web.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClaimHelper _claimHelper;

        public HomeController(ILogger<HomeController> logger, IClaimHelper claimHelper)
        {
            _logger = logger;
            _claimHelper = claimHelper;
        }

        public IActionResult Index()
        {
            var id = _claimHelper.UserId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
