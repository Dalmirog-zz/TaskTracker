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
        public ProjectsRepository(IDbConnection dbconn)
        {
            db = dbconn;
        }

        private IDbConnection db;

        public Project Find(int id)
        {
            return this.db.Query<Project>("Select * FROM Projects WHERE Id = @Id ", new {Id = id}).SingleOrDefault();
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