using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TaskTracker.Models;

namespace TaskTracker.Controllers.Repositories
{
    public class TagsRepository : IResourceRepository<Tag>
    {
        private const string SqlStringFindTagById = @"Select Id, Name FROM Tags WHERE Id = @Id ";
        private const string SqlStringFindTags = "Select * FROM Tags";
        private const string SqlStringInsertTag = "INSERT INTO [dbo].[Tags]([Name])VALUES(@Name); select CAST(SCOPE_IDENTITY() as int)";

        private readonly string connectionString;

        public TagsRepository() : this(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString)
        {
        }

        public TagsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Tag Find(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Tag>(SqlStringFindTagById, new { Id = id }).SingleOrDefault();
            }
        }

        public List<Tag> GetAll()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Tag>(SqlStringFindTags).ToList();

            }
        }

        public Tag Add(Tag resource)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var id = db.Query<int>(SqlStringInsertTag, resource).Single();
                resource.Id = id;
            }
            return resource;
        }

        public Tag Update(Tag resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public void Remove(Tag resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}