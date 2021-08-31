using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Helpers;
using Vehiculos.API.Models;

namespace Vehiculos.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioHelper _usuarioHelper;

        public AccountController(IUsuarioHelper usuarioHelper)
        {
            _usuarioHelper = usuarioHelper;
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }


            return View(new LoginViewModel());
        }



        [HttpPost()]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _usuarioHelper.LoginAsync(loginViewModel);
                if (result.Succeeded)
                {
                    if(Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");

            }

            return View(loginViewModel);
        }


        ///
        public async Task<IActionResult> Logout()
        {
            await _usuarioHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
