using ProjectsManager.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsManager.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int GetLastId()
        {
            if (Items.Any())
            {
                return Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                return 0;
            }
        }
        
        public int AddNewItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public void RemoveAllItems()
        {
            Items.Clear();
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

    }
}
