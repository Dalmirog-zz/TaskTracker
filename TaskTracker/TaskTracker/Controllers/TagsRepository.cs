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
        private const string SqlStringFindTagById = "Select * FROM Tags WHERE Id = @Id ";
        private const string SqlStringFindTags = "Select * FROM Tags";
        private const string SqlStringInsertTag = "INSERT INTO [dbo].[Tags]([Name])VALUES(@Name); select CAST(SCOPE_IDENTITY() as int)";
        private const string SqlStringUpdateTag = "UPDATE [dbo].[Tags] SET [Name] = @Name WHERE Id = @Id ; Select * FROM Tags WHERE Id = @Id ";

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

        public Tag Save(Tag resource)
        {
            using (var db = new SqlConnection(connectionString))
            {
                if (resource.Id == 0)
                {
                    var sql = SqlStringInsertTag;
                    var id = db.Query<int>(sql, resource).Single();
                    resource.Id = id;
                    return resource;
                }
                else
                {
                    var sql = SqlStringUpdateTag;
                    return db.Query<Tag>(sql, resource).Single();
                }
            }
        }
        public void Remove(Tag resource)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }


    }
}