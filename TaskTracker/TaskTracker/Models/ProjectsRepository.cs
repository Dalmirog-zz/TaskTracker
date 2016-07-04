using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace TaskTracker.Models
{
    public class ProjectsRepository : IResourceRepository<Project>
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

        public Project Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            return this.db.Query<Project>("Select * FROM Projects").ToList();
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