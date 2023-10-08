using ProjectsManager.App.Common;
using ProjectsManager.Domain.Entity;
using System;

namespace ProjectsManager.App.Concrete
{
    public class ProjectService : BaseService<Project>
    {
        public ConsoleKeyInfo ProjectTypeSelectionView()
        {
            Console.Clear();
            Console.WriteLine("Please select the type of project you want to see: ");
            Console.WriteLine();
            Console.WriteLine("1. Locomotives");
            Console.WriteLine("2. Trains");
            Console.WriteLine("3. Trams");
            Console.WriteLine("4. Metro");

            ConsoleKeyInfo projectId = Console.ReadKey();
            return projectId;
        }

        public int RemoveProjectTypeSelection()
        {
            Console.Clear();
            Console.WriteLine("Please select the type of project you want to remove: ");
            Console.WriteLine();
            Console.WriteLine("1. Locomotives");
            Console.WriteLine("2. Trains");
            Console.WriteLine("3. Trams");
            Console.WriteLine("4. Metro");

            var projectTypeId = Console.ReadKey();
            int id;

            if (int.TryParse(projectTypeId.KeyChar.ToString(), out id))
            {
                return id;
            }
            else
            {
                Console.WriteLine("Invalid input data type");
                return 0;
            }
        }
    }
}
