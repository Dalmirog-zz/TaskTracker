using System.Linq;
using NUnit.Framework;
using TaskTracker.Controllers;

namespace TaskTracker.Tests.Controllers
{

    [TestFixture]
    public class TagsControllerFixture
    {
        [Test]
        public void Can_Get_All_Tags_From_Controller()
        {
            var controller = new TagsController();
            var allTags = controller.Get().ToList();

            Assert.That(allTags, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Get_Tag_By_Id_From_Controller()
        {
            const int id = 1;

            var controller = new TagsController();
            var tag = controller.Get(id);

            Assert.That(tag.Id, Is.EqualTo(id));

        }
    }

}
