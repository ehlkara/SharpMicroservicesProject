using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SharpCourse.Web.Models;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _ıdentityService;

        public AuthController(IIdentityService ıdentityService)
        {
            _ıdentityService = ıdentityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SigninInput signinInput)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var response = await _ıdentityService.SignIn(signinInput);

            if(!response.IsSuccessful)
            {
                response.Errors.ForEach(err =>
                {
                    ModelState.AddModelError(String.Empty, err);
                });
                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _ıdentityService.RevokeRefreshToken();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}