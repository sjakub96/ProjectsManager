using ProjectsManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManager.App
{
    public interface IService<T>
    {
        int GetLastId();
        List<T> Projects { get; set; }

        List<T> ShowAllProjects();

        int AddNewProject(T project);

        void RemoveAllProjects();
        void RemoveProject(T project);

    }
}
