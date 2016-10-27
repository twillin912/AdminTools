using AdminTools.Services;
using AdminTools.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdminTools.Web.Controllers
{
    [Authorize]
    public class ToolsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Password()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Password(PasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordServices = new PasswordServices();
                ICollection<string> passwords = passwordServices.GeneratePasswords(model.Length, model.Symbols, model.Count);
                Dictionary<string, string> passpairs = new Dictionary<string, string>();
                foreach (string password in passwords)
                {
                    string phonetic = passwordServices.GetPhoneticPassword(password);
                    passpairs.Add(password, phonetic);
                }
                @ViewBag.Passwords = passpairs;
            }
            return View(model);
        }

    }
}
