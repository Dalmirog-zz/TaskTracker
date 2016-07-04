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
    }
}
