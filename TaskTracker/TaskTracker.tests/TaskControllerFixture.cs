using NUnit.Framework;
using System.Linq;
using TaskTracker.Controllers;

namespace TaskTracker.Tests
{

    [TestFixture]
    public class TaskControllerFixture
    {
        [Test]
        public void Can_Get_All_Tasks()
        {
            var controller = new TaskController();
            var allTasks = controller.Get().ToList();

            Assert.That(allTasks, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Get_Transit_Route_By_Id()
        {
            const int id = 1;

            var controller = new TaskController();
            var task = controller.Get(id);

            Assert.That(task.Id, Is.EqualTo(id));

        }
    }

}
