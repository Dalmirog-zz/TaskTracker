using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class ProjectsController : ApiController
    {
        private readonly ProjectsRepository repository = new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

        // GET: api/Projects
        public List<Project> Get()
        {
            return repository.GetAll();
        }

        // GET: api/Projects/5
        public Project Get(int id)
        {
            return repository.Find(id);
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
