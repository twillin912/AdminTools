using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace AdminTools.Web.Navigation
{
    public class MenuDataRepository
    {
        private IHostingEnvironment _env;

        public Menu MenuList { get; set; }

        public MenuDataRepository(IHostingEnvironment env)
        {
            _env = env;
        }

        public Task<Menu> GetMenu()
        {
            MenuList = new Menu();
            MenuList.MenuItems.Add(new MenuItem(100, "Home", "Index", "Home", 0));

            MenuList.MenuItems.Add(new MenuItem(400, "Tools", "", "Tools", 0));
            MenuList.MenuItems.Add(new MenuItem(401, "Tools", "Password", "Password Generator", 400));

            return Task.FromResult<Menu>(MenuList);
        }
    }
}
