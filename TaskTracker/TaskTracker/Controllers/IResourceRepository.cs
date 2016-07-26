using System.Collections.Generic;

namespace TaskTracker.Controllers
{
    public interface IResourceRepository<T>
    {
        T Find(int id);
        List<T> GetAll();
        T Save(T resource);
        void Remove(T resource);
        void Remove(int Id);
    }
}
