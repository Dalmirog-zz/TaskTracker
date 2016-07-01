using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TagsController : ApiController
    {
        private readonly List<Tag> tags = new List<Tag>();

        public TagsController()
        {
            tags.Add(new Tag { Id = 1, Name = "HelpScout" });
            tags.Add(new Tag { Id = 2, Name = "Tender" });
            tags.Add(new Tag { Id = 3, Name = "Documentation" });
        }

        // GET: api/Tags
        public IEnumerable<Tag> Get()
        {
            return tags;
        }

        // GET: api/Tags/5
        public Tag Get(int id)
        {
            return tags.FirstOrDefault(t => t.Id == id);
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
