using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace TaskTracker.Models
{
    public class TagsRepository : IResourceRepository<Tag>
    {
        public TagsRepository(IDbConnection dbconn)
        {
            db = dbconn;
        }

        private IDbConnection db;

        public Tag Find(int id)
        {
            return this.db.Query<Tag>("Select * FROM Tags WHERE Id = @Id ", new { Id = id }).SingleOrDefault();
        }

        public List<Tag> GetAll()
        {
            return this.db.Query<Tag>("Select * FROM Tags").ToList();
        }

        public Tag Add(Tag resource)
        {
            var sql = "INSERT INTO [dbo].[Tags]([Name])VALUES(@Name);" +
                      "select CAST(SCOPE_IDENTITY() as int)";
            var id = this.db.Query<int>(sql, resource).Single();
            resource.Id = id;
            return resource;
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