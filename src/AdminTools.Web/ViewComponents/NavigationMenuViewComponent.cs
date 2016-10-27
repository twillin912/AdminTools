using AdminTools.Web.Navigation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminTools.Web.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        MenuDataRepository _menuDataRepository;

        public NavigationMenuViewComponent(MenuDataRepository menuDataRepository)
        {
            _menuDataRepository = menuDataRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Menu model = await _menuDataRepository.GetMenu();
            return View(model);
        }
    }
}
