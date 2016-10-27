using System.Collections.Generic;

namespace AdminTools.Web.Navigation
{
    public class Menu
    {
        public IList<MenuItem> MenuItems { get; set; }
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(int id, string controller, string action, string name, int parentid)
        {
            Id = id;
            ControllerName = controller;
            ActionName = action;
            Name = name;
            ParentId = parentid;
        }
    }
}
