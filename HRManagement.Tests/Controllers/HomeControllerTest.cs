using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRManagement;
using HRManagement.Controllers;
using HRManagement.Service;

namespace HRManagement.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;

        [TestInitialize]
        public void Init()
        {
            _controller = new HomeController(new MockMailService());
        }
        [TestMethod]
        public void Index()
        {


            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {

            // Act
            ViewResult result = _controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Act
            ViewResult result = _controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
