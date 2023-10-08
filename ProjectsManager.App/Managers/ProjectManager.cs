using Newtonsoft.Json;
using ProjectsManager.App.Concrete;
using ProjectsManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjectsManager.App.Managers
{
    public class ProjectManager
    {
        private readonly MenuActionService _menuActionService;
        private readonly IService<Project> _projectService;

        public ProjectManager(MenuActionService menuActionService, IService<Project> projectService)
        {
            _projectService = projectService;
            _menuActionService = menuActionService;
        }

        public int AddNewProject()
        {
            var addNewProjectMenu = _menuActionService.GetMenuActionByMenuName("SelectProjectMenu");

            Console.Clear();

            Console.WriteLine("Please select the type of the project: ");
            Console.WriteLine();

            for (int i = 0; i < addNewProjectMenu.Count; i++)
            {
                Console.WriteLine($"{addNewProjectMenu[i].Id}. {addNewProjectMenu[i].Name} ");
            }

            var userChoice = Console.ReadKey();
            Console.Clear();
            int typeId;
            if(int.TryParse(userChoice.KeyChar.ToString(), out typeId))
            {
                Console.WriteLine("Please write the name for the project: ");
                var name = Console.ReadLine();
                var lastId = _projectService.GetLastId();
                Project project = new Project(lastId + 1, name, typeId);
                _projectService.AddNewItem(project);
                return project.Id;
            }
            else
            {
                Console.WriteLine("Invalid input datas...");
                return 0;
            }
        }

        public void ShowAllProjects(ConsoleKeyInfo typeId)
        {
            int typeIdInt;

            if(int.TryParse(typeId.KeyChar.ToString(), out typeIdInt))
            {
                List<Project> toShow = _projectService.ShowAllItems();
                List<Project> toShowList = new List<Project>();

                foreach (var project in toShow)
                {
                    if (project.TypeId == typeIdInt)
                    {
                        toShowList.Add(project);
                    }
                }

                Console.Clear();

                foreach (var item in toShowList)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }

                Console.ReadKey();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input data...");
                Console.WriteLine();
                Console.WriteLine("0 - Main Menu");
                Console.ReadKey();
            }
        }
        
        public void RemoveProject(int removeProjectId, string projectName, int typeId)
        {
            List<Project> toShow = _projectService.ShowAllItems();
            Project projectToRemove = new Project(removeProjectId, projectName, typeId);

            foreach (var project in toShow)
            {
                if (project.Id == removeProjectId && project.TypeId == typeId && project.Name == projectName)
                {
                    projectToRemove = project;
                    break;
                }
            }

            _projectService.RemoveItem(projectToRemove);
        }
        
        public string RemoveProjectGetName(int removeProjectId, int typeId)
        {
            List<Project> toShow = _projectService.ShowAllItems();
            
            string projectName;

            foreach (var project in toShow)
            {

                if (project.Id == removeProjectId && project.TypeId == typeId)
                {
                    projectName = project.Name;
                    return projectName;
                }
            }

            return null;

        }

        public int RemoveProjectView(int typeIdInt)
        {
            List<Project> toShow = _projectService.ShowAllItems();
            List<Project> toShowList = new List<Project>();

            foreach (var project in toShow)
            {
                if (project.TypeId == typeIdInt)
                {
                    toShowList.Add(project);
                }
            }
            
            Console.Clear();

            for (int i = 0; i < toShowList.Count; i++)
            {
                Console.WriteLine($"{toShowList[i].Id}. {toShowList[i].Name}");
            }

            Console.WriteLine();

            var projectId = Console.ReadKey();
            int projectToRemoveId;

            if (int.TryParse(projectId.KeyChar.ToString(), out projectToRemoveId))
            {
                return (projectToRemoveId);
            }
            else
            {
                Console.WriteLine("Invalid input data type");
                return 0;
            }
        }

        public void AddStartupProjects()
        {
            Project loco1 = new Project(1, "Dragon", 1);
            _projectService.AddNewItem(loco1);

            Project loco2 = new Project(2, "Gryffin", 1);
            _projectService.AddNewItem(loco2);

            Project ezt1 = new Project(1, "37WEa - LU", 2);
            _projectService.AddNewItem(ezt1);

            Project ezt2 = new Project(2, "31WEb - MLP", 2);
            _projectService.AddNewItem(ezt2);

            Project tram1 = new Project(1, "Stadler Tango", 3);
            _projectService.AddNewItem(tram1);

            Project tram2 = new Project(2, "Bombardier Flexity Classic", 3);
            _projectService.AddNewItem(tram2);

            Project metro1 = new Project(1, "Metro Sofia", 4);
            _projectService.AddNewItem(metro1);

            Project metro2 = new Project(2, "Metro Warsaw", 4);
            _projectService.AddNewItem(metro2);
        }
    }
}
