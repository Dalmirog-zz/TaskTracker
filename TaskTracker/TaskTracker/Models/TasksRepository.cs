using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class TasksRepository : IRepository<Task>
    {
        public Task Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Task resource)
        {
            throw new NotImplementedException();
        }

        public Task Update(Task resource)
        {
            throw new NotImplementedException();
        }

        public void Remove(Task resource)
        {
            throw new NotImplementedException();
        }
    }
}