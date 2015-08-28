using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Playground.CQRS.Infrastructure.Messaging;
using Playground.CQRS.Web.Controllers;
using System.Web.Mvc;

namespace Playground.CQRS.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<ICommandBus> _commandBus;
        private HomeController _controller;

        [TestInitialize]
        public void Setup()
        {
            this._commandBus = new Mock<ICommandBus>();
            this._controller = new HomeController(this._commandBus.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            ViewResult result = this._controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Act
            ViewResult result = this._controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Act
            ViewResult result = this._controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
