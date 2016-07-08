using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TagsController : ApiController
    {
        private readonly TagsRepository repository = new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

        // GET: api/Tags
        public List<Tag> Get()
        {
            return repository.GetAll();
        }

        // GET: api/Tags/5
        public Tag Get(int id)
        {
            return repository.Find(id);
        }

        // POST: api/Tags
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tags/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tags/5
        public void Delete(int id)
        {
        }
    }
}
