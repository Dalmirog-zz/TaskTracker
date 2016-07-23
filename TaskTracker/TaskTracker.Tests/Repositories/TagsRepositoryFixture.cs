using System;
using System.Configuration;
using NUnit.Framework;
using TaskTracker.Controllers.Repositories;
using TaskTracker.Models;

namespace TaskTracker.Tests.Repositories
{
    [TestFixture]
    public class TagsRepositoryFixture
    {
        [Test]
        public void Can_Get_All_Tags_From_Repository()
        {
            TagsRepository repository = new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);
            var allTags = repository.GetAll();
            Assert.That(allTags, Has.Count.GreaterThan(0));
        }

        [Test]
        public void Can_Create_Task_And_Get_By_ID_From_Repository()
        {
            TagsRepository repository = new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var testValue = "TestTag";
            var tag = new Tag
            {
                Name = testValue

            };
            var newTag = repository.Save(tag);

            Assert.That(newTag.Id, Is.Not.EqualTo(0));
            Assert.That(newTag.Name, Is.EqualTo(testValue));

            var tagByID = repository.Find(newTag.Id);

            Assert.That(tagByID.Id, Is.EqualTo(newTag.Id));
            Assert.That(tagByID.Name, Is.EqualTo(testValue));
        }

        [Test]
        public void Can_Create_Task_And_Update_From_Repository()
        {
            TagsRepository repository = new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);

            var testValue = "TestTag";
            var updatedValue = "UpdatedTag";
            var tag = new Tag
            {
                Name = testValue
            };
            var newTag = repository.Save(tag);

            newTag.Name = updatedValue;

            var updatedTag = repository.Save(newTag);

            Assert.That(updatedTag.Id, Is.EqualTo(newTag.Id));
            Assert.That(updatedTag.Name, Is.EqualTo(updatedValue));
        }
    }
}
