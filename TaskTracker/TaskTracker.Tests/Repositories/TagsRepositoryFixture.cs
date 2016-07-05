using System;
using NUnit.Framework;
using TaskTracker.Models;

namespace TaskTracker.Tests.Repositories
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
        [Test]
        public void Can_Get_Tags_By_Id_From_Repository()
        {
            var allTags = Repository.Tags.GetAll();
            int i = new Random().Next(0, allTags.Count - 1);
            var Tag = allTags[i];

            Assert.That(Repository.Tags.Find(Tag.Id).Name, Is.EqualTo(Tag.Name));
        }
    }
}
