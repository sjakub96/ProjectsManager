using System.Collections.Generic;

namespace ProjectsManager.App
{
    public interface IService<T>
    {
        int GetLastId();

        List<T> Items { get; set; }

        int AddNewItem(T item);

        void RemoveAllItems();

        void RemoveItem(T item);
    }
}
