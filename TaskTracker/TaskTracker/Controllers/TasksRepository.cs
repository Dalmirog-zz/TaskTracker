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
        private const string SqlStringInsertTask = @"INSERT INTO [dbo].[Tasks]
                                                   ([ProjectID]
                                                   ,[TagID]
                                                   ,[Name]
                                                   ,[Description])
                                             VALUES
                                                   (@ProjectId
                                                   ,@TagId
                                                   ,@Name
                                                   ,@Description);
                                            select CAST(SCOPE_IDENTITY() as int)";
        private const string SqlStringUpdateTask = @"UPDATE [dbo].[Tasks]
                                                       SET [ProjectID] = @ProjectID
                                                          ,[TagID] = @TagId
                                                          ,[Name] = @Name
                                                          ,[Description] = @Description
                                                     WHERE Id = @Id;
                                                    Select * FROM Tasks WHERE Id = @Id";

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

        public Task Save(Task resource)
        {
            var sql = "";

            if (resource.Id == 0) // INSERT task
            {
                sql = SqlStringInsertTask;
            }
            else // UPDATE task
            {
                sql = SqlStringUpdateTask;
            }

            //Persisting project in task
            if (resource.Project != null) { 
                resource.Project = projectRepository.Save(resource.Project);
            }
            //Persisting Tags in task
            var pTags = new List<Tag>();

            if(resource.Tags != null) { 
                foreach (Tag t in resource.Tags)
                {
                    pTags.Add(tagRepository.Save(t));
                }
            }

            resource.Tags = pTags;

            //Converting Task to DBTask to send to SQL
            var dbTask = TaskConverter(resource);

            using (var db = new SqlConnection(connectionString))
            {
                //Sending [DBtask] to SQL and re-converting the returned value to [Task]
                var taskID = db.Query<int>(sql, dbTask).Single();
                resource.Id = taskID;    
                //Returning the task
                return resource;
            }
            
        }

        public void Remove(Task resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        private Task TaskConverter(DBTask dbTask)
        {
            var project = projectRepository.Find(dbTask.ProjectId);

            var tags = new List<Tag>();
            if (!string.IsNullOrEmpty(dbTask.TagId))
            {
                foreach (var t in dbTask.TagId.Split(','))
                {
                    tags.Add(tagRepository.Find(Int32.Parse(t)));
                }
            }
            
            return new Task
            {
                Id = dbTask.Id,
                Description = dbTask.Description,
                Name = dbTask.Name,
                Project = project,
                Tags = tags
            };
        }

        private DBTask TaskConverter(Task task)
        {
            //I'm sooo sure there's a prettier way to get all the IDs in Task.tags.ID insto a single comma sepparated string.
            var tagsString = "";
            int projectId = 0;
            string description = "";

            if(task.Tags.Count == 0) { 
                foreach (var t in task.Tags)
                {
                    if (string.IsNullOrWhiteSpace(tagsString))
                    {
                        tagsString = t.Id.ToString();
                    }
                    else { 
                        tagsString = string.Join(",", tagsString,t.Id);
                    }
                }
            }

            if (task.Project != null)
            {
                projectId = task.Project.Id;
            }
            if (task.Description != null)
            {
                description = task.Description;
            }

            return new DBTask
            {
                Id = task.Id,
                Description = description,
                Name = task.Name,
                TagId = tagsString,
                ProjectId = projectId
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
                var project = new Project();

                if (!string.IsNullOrEmpty(dbtask.ProjectId.ToString()))
                {
                    project = allProjects.FirstOrDefault(p => p.Id == dbtask.ProjectId);
                }

                if (!string.IsNullOrEmpty(dbtask.TagId)) { 
                    var tagIDs = dbtask.TagId.Split(',');

                    foreach (var id in tagIDs)
                    {
                        tags.Add(allTags.FirstOrDefault(t => t.Id == Int32.Parse(id)));
                    }
                }
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
    }
}