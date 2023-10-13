using ProjectsManager.App.Common;
using ProjectsManager.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsManager.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        
        public List<MenuAction> GetMenuActionByMenuName(string menuName)
        {
            return Items.Where(x => x.MenuName == menuName).ToList();

            /*
            List<MenuAction> result = new List<MenuAction>();

            foreach (var menuAction in Items)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }

            return result;
            */
        }

        private void Initialize()
        {
            AddNewItem(new MenuAction(1, "Show all projects", "Main"));
            AddNewItem(new MenuAction(2, "Add project", "Main"));
            AddNewItem(new MenuAction(3, "Remove project", "Main"));
            AddNewItem(new MenuAction(6, "Import from XML", "Main"));
            AddNewItem(new MenuAction(7, "Import from JSON", "Main"));
            AddNewItem(new MenuAction(8, "Export to XML", "Main"));
            AddNewItem(new MenuAction(9, "Export to JSON", "Main"));
            AddNewItem(new MenuAction(0, "Exit program", "Main"));

            AddNewItem(new MenuAction(1, "Locomotives", "SelectProjectMenu"));
            AddNewItem(new MenuAction(2, "Trains", "SelectProjectMenu"));
            AddNewItem(new MenuAction(3, "Trams", "SelectProjectMenu"));
            AddNewItem(new MenuAction(4, "Metro", "SelectProjectMenu"));
        }
    }
}
