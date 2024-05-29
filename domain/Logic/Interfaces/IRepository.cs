

namespace Logic.Inrefaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllItem();
        T? GetItemById(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(T item);
        void Save();
    }
}