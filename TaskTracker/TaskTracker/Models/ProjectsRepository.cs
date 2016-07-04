using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class ProjectsRepository : IRepository<Project>
    {
        public Project Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public Project Add(Project resource)
        {
            throw new NotImplementedException();
        }

        public Project Update(Project resource)
        {
            throw new NotImplementedException();
        }

        public void Remove(Project resource)
        {
            throw new NotImplementedException();
        }
    }
}