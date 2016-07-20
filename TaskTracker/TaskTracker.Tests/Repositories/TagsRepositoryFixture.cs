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
        public void Can_Get_Tags_By_Id_From_Repository()
        {
            TagsRepository repository = new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);
            var allTags = repository.GetAll();
            int i = new Random().Next(0, allTags.Count - 1);
            var tag = allTags[i];

            Assert.That(repository.Find(tag.Id).Name, Is.EqualTo(tag.Name));
        }
        [Test]
        public void Can_Add_Tag()
        {
            var tag = new Tag
            {
                Name = "TestTag"

            };
            TagsRepository repository = new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);
            var newTag = repository.Save(tag);
            Assert.That(newTag.Id, Is.Not.EqualTo(0));
            Console.WriteLine("New ID: " + newTag.Id);
        }

        [Test]
        public void Can_Update_Tag()
        {
            TagsRepository repository = new TagsRepository(ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString);
            var allTags = repository.GetAll();
            int i = new Random().Next(0, allTags.Count - 1);
            var tag = allTags[i];

            var updatedValue = "Updated from test";

            tag.Name = updatedValue;

            var updatedTag = repository.Save(tag);

            Assert.That(updatedTag.Name, Is.EqualTo(updatedValue));
            Assert.That(updatedTag.Id, Is.EqualTo(tag.Id));
            Console.WriteLine("New Tag Name: " + updatedTag.Name);
        }
    }
}
