using System;
using System.Configuration;
using NUnit.Framework;
using TaskTracker.Controllers.Repositories;
using TaskTracker.Models;

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
        public void Can_Create_Task_And_Get_By_ID_From_Repository()
        {
            var repository = new TasksRepository(
                new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString),
                new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString));

            var testValue = "TestValue";

            var task = new Task
            {
                Name = "TestValue"
            };

            var newTask = repository.Save(task);

            Assert.That(newTask.Id, Is.Not.EqualTo(0));
            Assert.That(newTask.Name, Is.EqualTo(testValue));

            var taskByID = repository.Find(newTask.Id);

            Assert.That(taskByID.Id, Is.EqualTo(newTask.Id));
            Assert.That(taskByID.Name, Is.EqualTo(testValue));
        }

        [Test]
        public void Can_Create_Task_And_Update_From_Repository()
        {
            var repository = new TasksRepository(
                new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString),
                new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString));

            var testValue = "TestValue";
            var updatedValue = "UpdatedValue";

            var task = new Task
            {
                Name = "TestValue"
            };

            var newTask = repository.Save(task);

            newTask.Name = updatedValue;

            var updatedTask = repository.Save(newTask);

            Assert.That(updatedTask.Id, Is.EqualTo(newTask.Id));
            Assert.That(updatedTask.Name, Is.EqualTo(updatedValue));
        }

        [Test]
        public void Can_Create_Task_And_Remove_From_Repository()
        {
            var repository = new TasksRepository(
                new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString),
                new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString));

            var testValue = "TestValue";

            var task = new Task
            {
                Name = "TestValue"
            };

            var newTask = repository.Save(task);

            Assert.That(newTask.Id, Is.Not.EqualTo(0));
            Assert.That(newTask.Name, Is.EqualTo(testValue));

            repository.Remove(task.Id);

            Assert.That(repository.Find(newTask.Id),Is.Null);
        }
    }
}