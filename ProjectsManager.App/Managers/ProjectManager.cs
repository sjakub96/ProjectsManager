using ProjectsManager.App.Concrete;
using ProjectsManager.Domain.Common;
using ProjectsManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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

        public void ExportToXML()
        {
            var projects = _projectService.ShowAllProjects();
            var path = @"C:\Users\Dziku\Desktop\Tutoriale C#\Szkoła dotNeta\Praca domowa\ProjectsManager\ProjectsManager\XML\projects.xml";

            XmlRootAttribute rootAttribute = new XmlRootAttribute();
            rootAttribute.ElementName = "Projects";
            rootAttribute.IsNullable = true;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Project>), rootAttribute);

            using StreamWriter streamWriter = new StreamWriter(path);
            xmlSerializer.Serialize(streamWriter, projects);

        }

        public void ExportToJSON()
        {
            var projects = _projectService.ShowAllProjects();
            var path = @"C:\Users\Dziku\Desktop\Tutoriale C#\Szkoła dotNeta\Praca domowa\ProjectsManager\ProjectsManager\JSON\projects.json";


            var output = JsonConvert.SerializeObject(projects, Formatting.Indented);


            File.WriteAllText(path, output);
        }

        public void ImportFromXML()
        {
            var path = @"C:\Users\Dziku\Desktop\Tutoriale C#\Szkoła dotNeta\Praca domowa\ProjectsManager\ProjectsManager\XML\projects.xml";

            XmlRootAttribute rootAttribute = new XmlRootAttribute();
            rootAttribute.ElementName = "Projects";
            rootAttribute.IsNullable = true;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Project>), rootAttribute);

            var xml = File.ReadAllText(path);

            StringReader stringReader = new StringReader(xml);

            var itemsFromXml = (List<Project>)xmlSerializer.Deserialize(stringReader);

            if (_projectService.ShowAllProjects().Count != 0)
            {
                _projectService.RemoveAllProjects();

                foreach (var item in itemsFromXml)
                {
                    _projectService.AddNewProject(item);
                }
            }
            else
            {
                foreach (var item in itemsFromXml)
                {
                    _projectService.AddNewProject(item);
                }
            }
            

        }

        public void ImportFromJSON()
        {
            var path = @"C:\Users\Dziku\Desktop\Tutoriale C#\Szkoła dotNeta\Praca domowa\ProjectsManager\ProjectsManager\JSON\projects.json";

            var json = File.ReadAllText(path);

            var projects = JsonConvert.DeserializeObject<List<Project>>(json);

            if (_projectService.ShowAllProjects().Count != 0)
            {
                _projectService.RemoveAllProjects();

                foreach (var project in projects)
                {
                    _projectService.AddNewProject(project);
                }
            }
            else
            {
                foreach (var project in projects)
                {
                    _projectService.AddNewProject(project);
                }
            }

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
                _projectService.AddNewProject(project);
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
                List<Project> toShow = _projectService.ShowAllProjects();
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
            List<Project> toShow = _projectService.ShowAllProjects();
            Project projectToRemove = new Project(removeProjectId, projectName, typeId);


            foreach (var project in toShow)
            {
                
                if (project.Id == removeProjectId && project.TypeId == typeId && project.Name == projectName)
                {
                    projectToRemove = project;
                    break;
                }
            }

            _projectService.RemoveProject(projectToRemove);
        }
        
        public string RemoveProjectGetName(int removeProjectId, int typeId)
        {
            List<Project> toShow = _projectService.ShowAllProjects();
            
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
            List<Project> toShow = _projectService.ShowAllProjects();
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
            _projectService.AddNewProject(loco1);

            Project loco2 = new Project(2, "Gryffin", 1);
            _projectService.AddNewProject(loco2);

            Project ezt1 = new Project(1, "37WEa - LU", 2);
            _projectService.AddNewProject(ezt1);

            Project ezt2 = new Project(2, "31WEb - MLP", 2);
            _projectService.AddNewProject(ezt2);

            Project tram1 = new Project(1, "Stadler Tango", 3);
            _projectService.AddNewProject(tram1);

            Project tram2 = new Project(2, "Bombardier Flexity Classic", 3);
            _projectService.AddNewProject(tram2);

            Project metro1 = new Project(1, "Metro Sofia", 4);
            _projectService.AddNewProject(metro1);

            Project metro2 = new Project(2, "Metro Warsaw", 4);
            _projectService.AddNewProject(metro2);
        }
    }
}
