using System;
using NUnit.Framework;
using TaskTracker.Models;

namespace TaskTracker.Tests.Repositories
{
    [TestFixture]
    public class TagsRepositoryFixture
    {
        private Repository _repository = new Repository();

        [Test]
        public void Can_Get_All_Tags_From_Repository()
        {
            var allTags = _repository.Tags.GetAll();
            Assert.That(allTags, Has.Count.GreaterThan(0));
        }
        [Test]
        public void Can_Get_Tags_By_Id_From_Repository()
        {
            var allTags = _repository.Tags.GetAll();
            int i = new Random().Next(0, allTags.Count - 1);
            var tag = allTags[i];

            Assert.That(_repository.Tags.Find(tag.Id).Name, Is.EqualTo(tag.Name));
        }
    }
}
