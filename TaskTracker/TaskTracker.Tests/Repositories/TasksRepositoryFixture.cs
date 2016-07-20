using System;
using System.Configuration;
using NUnit.Framework;
using TaskTracker.Controllers.Repositories;

namespace TaskTracker.Tests.Repositories
{
    [TestFixture]
    public class TasksRepositoryFixture
    {
        [Test]
        public void Can_Get_All_Tasks_From_Repository()
        {
            var repository = new TasksRepository(
                new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString),
                new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString));

            var allTasks = repository.GetAll();
            Assert.That(allTasks, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Get_Tasks_By_Id_From_Repository()
        {
            var repository = new TasksRepository(
                new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString),
                new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString));

            var allTasks = repository.GetAll();
            var i = new Random().Next(0, allTasks.Count - 1);
            var task = allTasks[i];

            Assert.That(repository.Find(task.Id).Name, Is.EqualTo(task.Name));
        }

        [Test]
        public void Can_Save_Existing_Task()
        {
            var repository = new TasksRepository(
                new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString),
                new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString));

            var allTasks = repository.GetAll();
            var i = new Random().Next(0, allTasks.Count - 1);
            var task = allTasks[i];

            var updatedValue = "Updated from test";
            task.Description = updatedValue;

            var updatedTask = repository.Save(task);

            Assert.That(updatedTask.Description, Is.EqualTo(task.Description));
            Assert.That(updatedTask.Id, Is.EqualTo(task.Id));
        }
    }
}