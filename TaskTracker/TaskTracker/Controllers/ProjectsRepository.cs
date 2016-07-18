using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TaskTracker.Models;

namespace TaskTracker.Controllers.Repositories
{
    public class ProjectsRepository : IResourceRepository<Project>
    {
        private const string SqlStringFindProjectById = "Select * FROM Projects WHERE Id = @Id ";

        private const string SqlStringFindProjects = "Select * FROM Projects";

        private const string SqlStringInsertProject = "INSERT INTO [dbo].[Projects]([Name],[Description])VALUES(@Name,@Description); select CAST(SCOPE_IDENTITY() as int)";

        private readonly string connectionString;

        public ProjectsRepository() : this(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString)
        {
        }

        public ProjectsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Project Find(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Project>(SqlStringFindProjectById, new { Id = id }).SingleOrDefault();
            }
        }

        public List<Project> GetAll()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Project>(SqlStringFindProjects).ToList();
            }
        }

        public Project Add(Project resource)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var sql = SqlStringInsertProject;
                var id = db.Query<int>(sql, resource).Single();
                resource.Id = id;
                return resource;
            }
        }

        public Project Update(Project resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public void Remove(Project resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}