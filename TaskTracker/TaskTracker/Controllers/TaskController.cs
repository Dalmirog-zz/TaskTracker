using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TaskController : ApiController
    {
        private readonly List<Task> tasks = new List<Task>();

        public TaskController()
        {
            tasks.Add(new Task { Id = 1, Name = "TenderTicket", Description = "http://Tender.com/tickets/1" });
            tasks.Add(new Task { Id = 2, Name = "HelpScoutTicket", Description = "http://HelpScout.com/tickets/1" });
            tasks.Add(new Task { Id = 3, Name = "BacklogReview", Description = "Reviewed backlog with #Team-Awesome" });
        }
        // GET: api/Tasks
        public IEnumerable<Task> Get()
        {
            return tasks;
        }

        // GET: api/Tasks/5
        public Task Get(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
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
