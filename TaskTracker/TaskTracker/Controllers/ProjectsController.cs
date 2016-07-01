using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class ProjectsController : ApiController
    {
        private readonly List<Project> projects = new List<Project>();

        public ProjectsController()
        {
            projects.Add(new Project { Id = 1, Name = "OctopusSupport", Description = "http://Tender.com/tickets/1" });
            projects.Add(new Project { Id = 2, Name = "TaskTrackerDev", Description = "http://HelpScout.com/tickets/1" });
            projects.Add(new Project { Id = 3, Name = "OctoposhDev", Description = "Reviewed backlog with #Team-Awesome" });
        }

        // GET: api/Projects
        public IEnumerable<Project> Get()
        {
            return projects;
        }

        // GET: api/Projects/5
        public Project Get(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }

        // POST: api/Projects
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Projects/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Projects/5
        public void Delete(int id)
        {
        }
    }
}
