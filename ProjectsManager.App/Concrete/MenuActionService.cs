using ProjectsManager.App.Common;
using ProjectsManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Projects)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }

            return result;
        }


        private void Initialize()
        {
            AddNewProject(new MenuAction(1, "Show all projects", "Main"));
            AddNewProject(new MenuAction(2, "Add project", "Main"));
            AddNewProject(new MenuAction(3, "Remove project", "Main"));
            AddNewProject(new MenuAction(6, "Import from XML", "Main"));
            AddNewProject(new MenuAction(7, "Import from JSON", "Main"));
            AddNewProject(new MenuAction(8, "Export to XML", "Main"));
            AddNewProject(new MenuAction(9, "Export to JSON", "Main"));
            AddNewProject(new MenuAction(0, "Exit program", "Main"));

            AddNewProject(new MenuAction(1, "Locomotives", "SelectProjectMenu"));
            AddNewProject(new MenuAction(2, "Trains", "SelectProjectMenu"));
            AddNewProject(new MenuAction(3, "Trams", "SelectProjectMenu"));
            AddNewProject(new MenuAction(4, "Metro", "SelectProjectMenu"));

        }
    }
}
