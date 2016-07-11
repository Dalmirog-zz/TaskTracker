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

        private Task TaskConverter(DBTask dbTask)
        {
            var project = projectRepository.Find(dbTask.ProjectId);

            var tags = new List<Tag>();

            foreach (var t in dbTask.TagId.Split(','))
            {
                tags.Add(tagRepository.Find(Int32.Parse(t)));
            }

            return new Task()
            {
                Id = dbTask.Id,
                Description = dbTask.Description,
                Name = dbTask.Name,
                Project = project,
                Tags = tags
            };
        }

        private List<Task> TaskConverter(List<DBTask> dbTasks)
        {
            var allTasks = new List<Task>();

            var allTags = tagRepository.GetAll();
            var allProjects = projectRepository.GetAll();

            foreach (DBTask dbtask in dbTasks)
            {
                var tags = new List<Tag>();
                var project = allProjects.FirstOrDefault(p => p.Id == dbtask.ProjectId);

                var tagIDs = dbtask.TagId.Split(',');

                foreach (var id in tagIDs)
                {
                    tags.Add(allTags.FirstOrDefault(t => t.Id == Int32.Parse(id)));
                }
;
                allTasks.Add(new Task
                {
                    Id = dbtask.Id,
                    Name = dbtask.Name,
                    Description = dbtask.Description,
                    Project = project,
                    Tags = tags
                });
            }

            return allTasks;
        }

        public Task Find(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var dbTask = db.Query<DBTask>(SqlStringFindTaskById, new { Id = id }).SingleOrDefault();

                return TaskConverter(dbTask);
            }
        }

        public List<Task> GetAll()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return TaskConverter(db.Query<DBTask>(SqlStringFindTasks).ToList());
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