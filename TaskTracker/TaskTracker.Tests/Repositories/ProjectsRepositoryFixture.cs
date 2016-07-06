using System;
using NUnit.Framework;
using TaskTracker.Models;

namespace TaskTracker.Tests.Repositories
{
    [TestFixture]
    public class ProjectsRepositoryFixture
    {
        private Repository _repository = new Repository();

        [Test]
        public void Can_Get_All_Projects_From_Repository()
        {
            var allProjects = _repository.Projects.GetAll();
            Assert.That(allProjects, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Get_Project_By_Id_From_Repository()
        {
            var allProjects = _repository.Projects.GetAll();
            int i = new Random().Next(0, allProjects.Count -1);
            var project = allProjects[i];

            Assert.That(_repository.Projects.Find(project.Id).Name, Is.EqualTo(project.Name));
        }
    }
}
