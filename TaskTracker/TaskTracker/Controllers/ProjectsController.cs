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
        private readonly Repository _repository = new Repository();

        // GET: api/Projects
        public List<Project> Get()
        {
            return _repository.Projects.GetAll();
        }

        // GET: api/Projects/5
        public Project Get(int id)
        {
            return _repository.Projects.Find(id);
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
