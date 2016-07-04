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
            throw new NotImplementedException();
        }

        public List<Tag> GetAll()
        {
            return this.db.Query<Tag>("Select * FROM Tags").ToList();
        }

        public Tag Add(Tag resource)
        {
            throw new NotImplementedException();
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