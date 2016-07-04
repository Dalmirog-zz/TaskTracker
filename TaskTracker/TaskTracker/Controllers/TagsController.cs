using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TagsController : ApiController
    {
        private readonly Repository _repository = new Repository();

        // GET: api/Tags
        public List<Tag> Get()
        {
            return _repository.Tags.GetAll();
        }

        // GET: api/Tags/5
        public Tag Get(int id)
        {
            return _repository.Tags.Find(id);
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
