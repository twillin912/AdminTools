using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTools.Web.Controllers
{
    public class ChangeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
