using System;
using NUnit.Framework;
using TaskTracker.Models;

namespace TaskTracker.Tests.Repositories
{
    [TestFixture]
    public class TasksRepositoryFixture
    {
        private Repository _repository = new Repository();

        [Test]
        public void Can_Get_All_Tasks_From_Repository()
        {
            var allTasks = _repository.Tasks.GetAll();
            Assert.That(allTasks, Has.Count.GreaterThan(0));
        }
        [Test]
        public void Can_Get_Tags_By_Id_From_Repository()
        {
            var allTasks = _repository.Tags.GetAll();
            int i = new Random().Next(0, allTasks.Count - 1);
            var task = allTasks[i];

            Assert.That(_repository.Tags.Find(task.Id).Name, Is.EqualTo(task.Name));
        }
    }
}
