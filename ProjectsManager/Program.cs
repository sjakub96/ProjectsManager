using ProjectsManager.App;
using ProjectsManager.App.Common;
using ProjectsManager.App.Concrete;
using ProjectsManager.App.Managers;
using ProjectsManager.Domain.Entity;
using System;

namespace ProjectsManager
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            //Użytkownik zostanie przywitany
            //Dostanie  menu (wybór projektu), z którego wybierze akcję.
            //a1 - wyświetl wszystkie projekty
            //a2 - dodaj projekt
            //a3 - usuń projekt

            //a1.1 - wyświetl możliwości - lokomotywa, ezt, metro, tramwaj
            //a1.2 - wyświetl wszystkie projekty danego typu

            //a2.1 - wybierz czy pojazd jest lokomotywa, ezt, pojazdem metra czy tramwajem
            //a2.2 - podaj id projektu oraz nazwę

            //a3.1 - wybierz czy pojazd jest lokomotywa, ezt, pojazdem metra czy tramwajem
            //a3.2 - podaj id projektu


            MenuActionService menuActionService = new MenuActionService();
            ProjectService projectService = new ProjectService();
            ProjectManager projectManager = new ProjectManager(menuActionService, projectService);


            projectManager.AddStartupProjects();

            Console.WriteLine("Welcome in project's manager");
            Console.WriteLine();

            while (true)
            {

                Console.WriteLine("Please select what you want to do: ");
                Console.WriteLine();

                var mainMenu = menuActionService.GetMenuActionByMenuName("Main");

                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var userChoice = Console.ReadKey();

                switch (userChoice.KeyChar)
                {
                    case '1':
                        var typeId = projectService.ProjectTypeSelectionView();
                        projectManager.ShowAllProjects(typeId);
                        break;
                    case '2':
                        var newId = projectManager.AddNewProject();
                        break;
                    case '3':
                        var removeTypeId = projectService.RemoveProjectTypeSelection();
                        var removeId = projectManager.RemoveProjectView(removeTypeId);
                        var removeProjectName = projectManager.RemoveProjectGetName(removeId, removeTypeId);
                        projectManager.RemoveProject(removeId, removeProjectName, removeTypeId);
                        break;
                    case '6':
                        projectManager.ImportFromXML();
                        break;
                    case '7':
                        projectManager.ImportFromJSON();
                        break;
                    case '8':
                        projectManager.ExportToXML();
                        break;
                    case '9':
                        projectManager.ExportToJSON();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Action not exists");
                        break;

                }

                Console.Clear();
            }


        }

       
    }
}
