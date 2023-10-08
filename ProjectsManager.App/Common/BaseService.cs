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
            int lastId;

            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }

            return lastId;
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

        public List<T> ShowAllItems()
        {
            return Items;
        }
    }
}
