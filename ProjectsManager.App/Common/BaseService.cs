using ProjectsManager.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsManager.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {

        public List<T> Projects { get; set; }
        public List<T> Faults { get; set; }

        public BaseService()
        {
            Projects = new List<T>();
        }

        public int GetLastId()
        {
            int lastId;

            if (Projects.Any())
            {
                lastId = Projects.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }

            return lastId;
        }
        
        public int AddNewProject(T project)
        {
            Projects.Add(project);
            return project.Id;
        }

        public void RemoveAllProjects()
        {
            Projects.Clear();
        }

        public void RemoveProject(T project)
        {
            Projects.Remove(project);
        }

        public List<T> ShowAllProjects()
        {
            return Projects;
        }


    }
}
