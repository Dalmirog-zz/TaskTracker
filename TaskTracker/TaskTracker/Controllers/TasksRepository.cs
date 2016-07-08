using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TasksRepository : IResourceRepository<Task>
    {
        private string connectionString;

        public TasksRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public Task Find(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Task>("Select * FROM Tasks WHERE Id = @Id ", new {Id = id}).SingleOrDefault();
            }
        }

        public List<Task> GetAll()
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<Task>("Select * FROM Tasks").ToList();
            }
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