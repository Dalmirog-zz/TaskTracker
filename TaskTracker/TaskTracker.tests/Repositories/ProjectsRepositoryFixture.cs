using NUnit.Framework;
using TaskTracker.Models;

namespace TaskTracker.tests.Repositories
{
    [TestFixture]
    public class ProjectsRepositoryFixture
    {
        private Repository Repository = new Repository();

        [Test]
        public void Can_Get_All_Projects_From_Repository()
        {
            var allProjects = Repository.Projects.GetAll();
            Assert.That(allProjects, Has.Count.GreaterThan(0));
        }
    }
}
