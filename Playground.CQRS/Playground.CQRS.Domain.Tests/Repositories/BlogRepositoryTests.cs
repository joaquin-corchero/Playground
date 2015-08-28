using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using Playground.CQRS.Domain.Dtos;
using Playground.CQRS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Playground.CQRS.Domain.Tests.Repositories
{
    public class when_working_with_the_blog_repository : RepositoryBase
    {
        protected BlogRepository _repository;

        protected override void Establish_context()
        {
            base.Establish_context();
            this._repository = new BlogRepository(base._dbContext);
        }

        protected void CreateItems(int blogsToCreate, bool withDelay = false)
        {
            for (var i = 1; i < (blogsToCreate + 1); i++)
            {
                var item = new Blog(Guid.NewGuid(), i.ToString(), string.Format("www.{0}.com", i));
                this._repository.Create(item);

                if (withDelay)
                    Thread.Sleep(1000);
            }
        }
    }

    [TestClass]
    public class and_creating_a_blog : when_working_with_the_blog_repository
    {
        [TestMethod]
        public void then_a_blog_can_be_created()
        {
            base.CreateItems(1);
            var actual = base._dbContext.Blogs.FirstOrDefault();
            actual.Name.ShouldEqual("1");
            actual.Url.ShouldEqual("www.1.com");
        }
    }

    [TestClass]
    public class and_updating_a_blog : when_working_with_the_blog_repository
    {
        private string _errorMessage;
        private Blog _blog;

        private void Execute()
        {
            try
            {
                this._repository.Update(this._blog);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
        }

        [TestMethod]
        public void then_a_blog_can_be_updated()
        {
            var newName = "New name";
            var newUrl = "www.newurl.com";
            base.CreateItems(1);
            this._blog = base._dbContext.Blogs.FirstOrDefault();
            this._blog.SetName(newName);
            this._blog.SetUrl(newUrl);
            this.Execute();
            this._blog.Name.ShouldEqual(newName);
            this._blog.Url.ShouldEqual(newUrl);
        }

        [TestMethod]
        public void then_if_the_blog_does_not_exist_exception_is_thrown()
        {
            var expected = "The blog couldn't be found";
            this._blog = new Blog(Guid.NewGuid(), "name", "url");
            this.Execute();
            this._errorMessage.ShouldEqual(expected);
        }
    }

    [TestClass]
    public class and_getting_the_latest_blogs : when_working_with_the_blog_repository
    {
        private List<Blog> _result;

        private void Execute()
        {
            this._result = base._repository.GetLatest();
        }

        [TestMethod]
        public void then_if_no_blogs_are_found_empty_list_is_returned()
        {
            this.Execute();
            this._result.Count.ShouldEqual(0);
        }

        [TestMethod]
        public void then_the_latests_posts_are_returned_first()
        {
            const int itemsToCreate = 5;
            this.CreateItems(itemsToCreate, true);
            this.Execute();
            this._result.Count.ShouldEqual(itemsToCreate);
            int i = 0;
            while (i < (itemsToCreate - 1))
            {
                var current = this._result[i].CreationDate;
                var next = this._result[i + 1].CreationDate;
                current.ShouldBeGreaterThan(next);
                i++;
            }
        }

        [TestMethod]
        public void then_only_the_ten_latest_posts_are_returned()
        {
            const int itemsToCreate = 15;
            this.CreateItems(itemsToCreate);
            this.Execute();
            this._result.Count.ShouldEqual(10);
        }
    }
}
