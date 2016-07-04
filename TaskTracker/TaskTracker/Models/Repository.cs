using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class Repository
    {
        private static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

        public ProjectsRepository Projects = new ProjectsRepository(db);
        public TasksRepository Tasks = new TasksRepository(db);
        public TagsRepository Tags = new TagsRepository(db);
    }
}