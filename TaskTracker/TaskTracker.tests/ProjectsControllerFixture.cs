using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Controllers;

namespace TaskTracker.tests
{
    [TestFixture]
    public class ProjectsControllerFixture
    {
        private ProjectsController PController = new ProjectsController();

        [Test]
        public void Can_Get_All_Projects()
        {
            var allProjects = PController.Get().ToList();
            Assert.That(allProjects, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Get_Project_By_Id()
        {
            var allProjects = PController.Get().ToList();
            int i = new Random().Next(0,allProjects.Count - 1);
            var project = allProjects[i];

            Assert.That(PController.Get(project.Id).Name, Is.EqualTo(project.Name));
        }
    }
}
