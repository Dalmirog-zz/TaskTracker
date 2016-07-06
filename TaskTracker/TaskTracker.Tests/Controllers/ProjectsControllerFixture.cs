using System;
using System.Linq;
using NUnit.Framework;
using TaskTracker.Controllers;

namespace TaskTracker.Tests.Controllers
{
    [TestFixture]
    public class ProjectsControllerFixture
    {
        private ProjectsController _pController = new ProjectsController();

        [Test]
        public void Can_Get_All_Projects_From_Controller()
        {
            var allProjects = _pController.Get().ToList();
            Assert.That(allProjects, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Get_Project_By_Id_From_Controller()
        {
            var allProjects = _pController.Get().ToList();
            int i = new Random().Next(0,allProjects.Count - 1);
            var project = allProjects[i];

            Assert.That(_pController.Get(project.Id).Name, Is.EqualTo(project.Name));
        }
    }
}
