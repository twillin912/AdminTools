using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AdminTools.Data;
using Microsoft.EntityFrameworkCore;

namespace AdminTools.Web.Controllers
{
    public class AssetController : Controller
    {
        private readonly DataContext _context;

        public AssetController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assets.ToListAsync());
        }

        public IActionResult Details()
        {
            var asset = _context.Assets.First();
            return View(asset);
        }
    }
}
