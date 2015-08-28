using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using Playground.CQRS.Domain.CommandHandlers;
using Playground.CQRS.Domain.Commands.BlogCommands;
using Playground.CQRS.Domain.Dtos;
using Playground.CQRS.Domain.Repositories;
using System;

namespace Playground.CQRS.Domain.Tests.CommandHandlers
{
    [TestClass]
    public class when_working_with_the_blog_command_handler : SpecBase
    {
        protected Mock<ICreateRepository<Blog>> _insertRepository;
        protected Mock<IUpdateRepository<Blog>> _updateRepository;

        protected BlogCommandHandler _blogCommandHandler;

        protected override void Establish_context()
        {
            base.Establish_context();
            this._insertRepository = new Mock<ICreateRepository<Blog>>();
            this._updateRepository = new Mock<IUpdateRepository<Blog>>();

            this._blogCommandHandler = new BlogCommandHandler(this._insertRepository.Object, this._updateRepository.Object);
        }

        [TestMethod]
        public void then_if_the_insert_repository_is_null_contract_exception_is_thrown()
        {
            var expected = "Precondition failed: insertRepository != null";
            var actual = string.Empty;
            try
            {
                this._blogCommandHandler = new BlogCommandHandler(null, this._updateRepository.Object);
            }
            catch (Exception e)
            {
                actual = e.Message;
            }

            actual.ShouldEqual(expected);
        }

        [TestMethod]
        public void then_if_the_update_repository_is_null_contract_exception_is_thrown()
        {
            var expected = "Precondition failed: updateRepository != null";
            var actual = string.Empty;
            try
            {
                this._blogCommandHandler = new BlogCommandHandler(this._insertRepository.Object, null);
            }
            catch (Exception e)
            {
                actual = e.Message;
            }

            actual.ShouldEqual(expected);
        }
    }

    [TestClass]
    public class and_executing_the_create_blog_command : when_working_with_the_blog_command_handler
    {
        private CreateBlogCommand _command;
        private string _errorMessage;

        protected override void Establish_context()
        {
            base.Establish_context();
            this._command = new CreateBlogCommand("Blog name", "www.url.com");
        }

        private void Execute()
        {
            try
            {
                base._blogCommandHandler.Execute(this._command);
            }
            catch (Exception e)
            {
                this._errorMessage = e.Message;
            }
        }

        [TestMethod]
        public void then_if_the_command_is_null_exception_is_thrown()
        {
            this._command = null;
            this.Execute();
            var expected = "Precondition failed: command != null";
            this._errorMessage.ShouldEqual(expected);
        }

        [TestMethod]
        public void then_if_the_command_is_valid_the_create_method_is_called()
        {
            this.Execute();
            base._insertRepository.Verify(s => s.Create(It.IsAny<Blog>()), Times.Once);
        }
    }

    [TestClass]
    public class and_executing_the_update_blog_command : when_working_with_the_blog_command_handler
    {
        private UpdateBlogCommand _command;
        private string _errorMessage;

        protected override void Establish_context()
        {
            base.Establish_context();
            this._command = new UpdateBlogCommand(Guid.NewGuid(), "Blog name", "www.url.com");
        }

        private void Execute()
        {
            try
            {
                base._blogCommandHandler.Execute(this._command);
            }
            catch (Exception e)
            {
                this._errorMessage = e.Message;
            }
        }

        [TestMethod]
        public void then_if_the_command_is_null_exception_is_thrown()
        {
            this._command = null;
            this.Execute();
            var expected = "Precondition failed: command != null";
            this._errorMessage.ShouldEqual(expected);
        }

        [TestMethod]
        public void then_if_the_command_is_valid_the_update_method_is_called()
        {
            this.Execute();
            base._updateRepository.Verify(s => s.Update(It.IsAny<Blog>()), Times.Once);
        }
    }
}