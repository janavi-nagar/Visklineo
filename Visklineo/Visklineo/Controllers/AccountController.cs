using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System;
using Visklineo.Business.Helpers;
using Visklineo.Business.ViewModels.User;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Visklineo.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Visklineo.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult SignUp()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Register(SignUpModel signUpModel)
        {
            var result = await PostAsync(signUpModel, "Login/SignUp");
            if (result.model != null && result.model.Equals("True"))
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                return View("SignUp");
            }
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            var result = await PostAsync(signInModel, "Login/Login");
            if(result.model != null)
            {
                HttpContext.Session.SetString("_token", result.model.ToString());
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("SignIn");
        }
    }
}
