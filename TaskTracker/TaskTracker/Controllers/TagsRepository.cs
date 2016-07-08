using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TagsRepository : IResourceRepository<Tag>
    {
        private string connectionString;
        public TagsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Tag Find(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Tag>("Select * FROM Tags WHERE Id = @Id ", new {Id = id}).SingleOrDefault();
            }
        }

        public List<Tag> GetAll()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Tag>("Select * FROM Tags").ToList();
            }
        }

        public Tag Add(Tag resource)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var sql = "INSERT INTO [dbo].[Tags]([Name])VALUES(@Name);" +
                          "select CAST(SCOPE_IDENTITY() as int)";
                var id = db.Query<int>(sql, resource).Single();
                resource.Id = id;
                return resource;
            }
        }

        public Tag Update(Tag resource)
        {
            throw new NotImplementedException();
        }

        public void Remove(Tag resource)
        {
            throw new NotImplementedException();
        }
    }
}