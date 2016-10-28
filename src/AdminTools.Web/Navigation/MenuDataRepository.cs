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

                MenuList.MenuItems.Add(new MenuItem(400, "Change", "", "Changes", 0));
                MenuList.MenuItems.Add(new MenuItem(401, "Change", "Index", "List Changes", 400));
            MenuList.MenuItems.Add(new MenuItem(900, "Tools", "", "Tools", 0));
            MenuList.MenuItems.Add(new MenuItem(901, "Tools", "Password", "Password Generator", 900));

            return Task.FromResult<Menu>(MenuList);
        }
    }
}
