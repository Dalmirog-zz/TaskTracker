using System;
using System.Configuration;
using NUnit.Framework;
using TaskTracker.Models;
using TaskTracker.Controllers.Repositories;

namespace TaskTracker.Tests.Repositories
{
    [TestFixture]
    public class ProjectsRepositoryFixture
    {
        [Test]
        public void Can_Get_All_Projects_From_Repository()
        {
            ProjectsRepository repository = new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var allProjects = repository.GetAll();
            Assert.That(allProjects, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Create_Project_And_Get_By_ID_From_Repository()
        {
            ProjectsRepository repository = new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var testValue = "TestValue";

            var project = new Project
            {
                 Name = testValue,
                 Description = testValue
            };

            var newProject = repository.Save(project);

            Assert.That(newProject.Id, Is.Not.EqualTo(0));
            Assert.That(newProject.Name, Is.EqualTo(testValue));

            var projectByID = repository.Find(newProject.Id);

            Assert.That(projectByID.Id, Is.EqualTo(newProject.Id));
            Assert.That(projectByID.Name, Is.EqualTo(testValue));
        }

        [Test]
        public void Can_Create_Project_And_Update_From_Repository()
        {
            ProjectsRepository repository = new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var testValue = "TestValue";
            var updatedValue = "UpdatedValue";

            var project = new Project
            {
                Name = testValue,
                Description = testValue
            };

            var newProject = repository.Save(project);

            newProject.Name = updatedValue;

            var updatedProject = repository.Save(newProject);

            Assert.That(updatedProject.Id, Is.EqualTo(newProject.Id));
            Assert.That(updatedProject.Name, Is.EqualTo(updatedValue));
        }

        [Test]
        public void Can_Create_Project_And_Remove_From_Repository()
        {
            ProjectsRepository repository = new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var testValue = "TestValue";

            var project = new Project
            {
                Name = testValue,
                Description = testValue
            };

            var newProject = repository.Save(project);

            Assert.That(newProject.Id, Is.Not.EqualTo(0));
            Assert.That(newProject.Name, Is.EqualTo(testValue));

            repository.Remove(newProject);

            Assert.That(repository.Find(newProject.Id),Is.Null);
        }
    }
}
