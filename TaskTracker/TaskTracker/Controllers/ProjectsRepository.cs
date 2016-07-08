using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class ProjectsRepository : IResourceRepository<Project>
    {
        private readonly string connectionString;

        public ProjectsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Project Find(int id)
        {
            using (var db = new SqlConnection(connectionString)) { 
                return db.Query<Project>("Select * FROM Projects WHERE Id = @Id ", new {Id = id}).SingleOrDefault();
            }
        }

        public List<Project> GetAll()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Project>("Select * FROM Projects").ToList();
            }
        }

        public Project Add(Project resource)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var sql = "INSERT INTO [dbo].[Projects]([Name],[Description])VALUES(@Name,@Description);" +
                          "select CAST(SCOPE_IDENTITY() as int)";
                var id = db.Query<int>(sql, resource).Single();
                resource.Id = id;
                return resource;
            }
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