using Boilerplate.Infrastructure.Dtos;
using Boilerplate.Infrastructure.Utilities;
using Boilerplate.Services.Contracts;
using Boilerplate.Services.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Boilerplate.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        //string returnUrl = null
        [HttpPost]
        public async Task<IActionResult> Index(string UserName,string password, string returnUrl = null)
        {
            try
            {

                if (string.IsNullOrEmpty(returnUrl)) { returnUrl = "/Home/Index"; }
                                
                var user = _userService.Login(UserName,password);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        new AuthenticationProperties { IsPersistent = true });

                return LocalRedirect(returnUrl);
            }
            catch (BadRequestException ex)
            {
                // handle validation message and display

                return View();
            }
            catch (Exception ex)
            {
                // display error page

                return View();
            }
        }
    }
}