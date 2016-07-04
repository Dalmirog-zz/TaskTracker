using NUnit.Framework;
using TaskTracker.Models;

namespace TaskTracker.tests.Repositories
{
    [TestFixture]
    public class TagsRepositoryFixture
    {
        private Repository Repository = new Repository();

        [Test]
        public void Can_Get_All_Tags_From_Repository()
        {
            var allTags = Repository.Tags.GetAll();
            Assert.That(allTags, Has.Count.GreaterThan(0));
        }
    }
}
