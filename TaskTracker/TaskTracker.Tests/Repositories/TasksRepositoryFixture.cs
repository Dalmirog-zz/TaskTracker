using System;
using System.Configuration;
using NUnit.Framework;
using TaskTracker.Controllers;
using TaskTracker.Models;

namespace TaskTracker.Tests.Repositories
{
    [TestFixture]
    public class TasksRepositoryFixture
    {
        [Test]
        public void Can_Get_All_Tasks_From_Repository()
        {
            TasksRepository repository = new TasksRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);
            var allTasks = repository.GetAll();
            Assert.That(allTasks, Has.Count.GreaterThan(0));
        }
        [Test]
        public void Can_Get_Tags_By_Id_From_Repository()
        {
            TasksRepository repository = new TasksRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);
            var allTasks = repository.GetAll();
            int i = new Random().Next(0, allTasks.Count - 1);
            var task = allTasks[i];

            Assert.That(repository.Find(task.Id).Name, Is.EqualTo(task.Name));
        }
    }
}
