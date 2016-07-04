using System;
using NUnit.Framework;
using TaskTracker.Models;

namespace TaskTracker.tests.Repositories
{
    [TestFixture]
    public class TasksRepositoryFixture
    {
        private Repository Repository = new Repository();

        [Test]
        public void Can_Get_All_Tasks_From_Repository()
        {
            var allTasks = Repository.Tasks.GetAll();
            Assert.That(allTasks, Has.Count.GreaterThan(0));
        }
        [Test]
        public void Can_Get_Tags_By_Id_From_Repository()
        {
            var allTasks = Repository.Tags.GetAll();
            int i = new Random().Next(0, allTasks.Count - 1);
            var Task = allTasks[i];

            Assert.That(Repository.Tags.Find(Task.Id).Name, Is.EqualTo(Task.Name));
        }
    }
}
