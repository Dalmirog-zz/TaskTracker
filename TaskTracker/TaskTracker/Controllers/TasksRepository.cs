using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TaskTracker.Models;

namespace TaskTracker.Controllers.Repositories
{
    public class TasksRepository : IResourceRepository<Task>
    {
        private const string SqlStringFindTasks = "Select * FROM Tasks";
        private const string SqlStringFindTaskById = "Select * FROM Tasks WHERE Id = @Id ";

        private readonly string connectionString;
        private readonly IResourceRepository<Project> projectRepository;
        private readonly IResourceRepository<Tag> tagRepository;

        public TasksRepository(IResourceRepository<Project> projectRepository, IResourceRepository<Tag> tagRepository) : this(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString, projectRepository, tagRepository)
        {
        }

        public TasksRepository(string connectionString, IResourceRepository<Project> projectRepository, IResourceRepository<Tag> tagRepository)
        {
            this.connectionString = connectionString;
            this.projectRepository = projectRepository;
            this.tagRepository = tagRepository;
        }

        public Task Find(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Task>(SqlStringFindTaskById, new { Id = id }).SingleOrDefault();
            }
        }

        public List<Task> GetAll()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Task>(SqlStringFindTasks).ToList();
            }
        }

        public Task Add(Task resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public Task Update(Task resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public void Remove(Task resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}