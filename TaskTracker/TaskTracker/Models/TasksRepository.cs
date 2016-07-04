using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace TaskTracker.Models
{
    public class TasksRepository : IResourceRepository<Task>
    {
        public TasksRepository(IDbConnection dbconn)
        {
            db = dbconn;
        }

        private IDbConnection db;

        public Task Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            return this.db.Query<Task>("Select * FROM Tasks").ToList();
        }

        public Task Add(Task resource)
        {
            throw new NotImplementedException();
        }

        public Task Update(Task resource)
        {
            throw new NotImplementedException();
        }

        public void Remove(Task resource)
        {
            throw new NotImplementedException();
        }
    }
}