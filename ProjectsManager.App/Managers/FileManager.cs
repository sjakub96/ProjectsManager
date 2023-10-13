using Newtonsoft.Json;
using ProjectsManager.Domain.Entity;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjectsManager.App.Managers
{
    public class FileManager
    {
        private readonly IService<Project> _projectService;

        public FileManager(IService<Project> projectService)
        {
            _projectService = projectService;
        }

        public void ExportToXML()
        {
            var projects = _projectService.Items;
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
            var projects = _projectService.Items;
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

            if (_projectService.Items.Count != 0)
            {
                _projectService.RemoveAllItems();

                foreach (var item in itemsFromXml)
                {
                    _projectService.AddNewItem(item);
                }
            }
            else
            {
                foreach (var item in itemsFromXml)
                {
                    _projectService.AddNewItem(item);
                }
            }
        }

        public void ImportFromJSON()
        {
            var path = @"C:\Users\Dziku\Desktop\Tutoriale C#\Szkoła dotNeta\Praca domowa\ProjectsManager\ProjectsManager\JSON\projects.json";

            var json = File.ReadAllText(path);

            var projects = JsonConvert.DeserializeObject<List<Project>>(json);

            if (_projectService.Items.Count != 0)
            {
                _projectService.RemoveAllItems();

                foreach (var project in projects)
                {
                    _projectService.AddNewItem(project);
                }
            }
            else
            {
                foreach (var project in projects)
                {
                    _projectService.AddNewItem(project);
                }
            }
        }
    }
}
