using System.Collections.Generic;

namespace TaskTracker.Models
{
    public class Task : ITask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public List<Tag> Tags { get; set; }
    }
}