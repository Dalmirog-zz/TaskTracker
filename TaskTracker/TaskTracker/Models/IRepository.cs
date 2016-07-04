using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public interface IRepository<T>
    {
        T Find(int id);
        List<T> GetAll();
        T Add(T resource);
        T Update(T resource);
        void Remove(T resource);

    }
}
