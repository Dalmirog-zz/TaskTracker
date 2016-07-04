using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TasksController : ApiController
    {
        private readonly Repository _repository = new Repository();

        // GET: api/Tasks
        public List<Task> Get()
        {
            return _repository.Tasks.GetAll();
        }

        // GET: api/Tasks/5
        public Task Get(int id)
        {
            return _repository.Tasks.Find(id);
        }

        // POST: api/Tasks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tasks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tasks/5
        public void Delete(int id)
        {
        }
    }
}
