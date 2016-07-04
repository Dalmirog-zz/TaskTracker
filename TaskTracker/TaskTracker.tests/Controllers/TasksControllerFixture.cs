using System.Linq;
using NUnit.Framework;
using TaskTracker.Controllers;

namespace TaskTracker.tests.Controllers
{

    [TestFixture]
    public class TasksControllerFixture
    {
        [Test]
        public void Can_Get_All_Tasks_From_Controller()
        {
            var controller = new TasksController();
            var allTasks = controller.Get().ToList();

            Assert.That(allTasks, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Get_Task_By_Id_From_Controller()
        {
            const int id = 1;

            var controller = new TasksController();
            var task = controller.Get(id);

            Assert.That(task.Id, Is.EqualTo(id));

        }
    }

}
