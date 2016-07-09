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
        public void Can_Get_Project_By_Id_From_Repository()
        {
            ProjectsRepository repository = new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var allProjects = repository.GetAll();
            int i = new Random().Next(0, allProjects.Count -1);
            var project = allProjects[i];

            Assert.That(repository.Find(project.Id).Name, Is.EqualTo(project.Name));
        }

        [Test]
        public void Can_Add_Project()
        {
            var project = new Project
            {
                 Name = "TestProject",
                 Description = "TestDescription"
                
            };
            ProjectsRepository repository = new ProjectsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var newProject = repository.Add(project);
            Assert.That(newProject.Id, Is.Not.EqualTo(0));
            Console.WriteLine("New ID: " + newProject.Id);
        }
    }
}
