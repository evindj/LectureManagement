using System;
using System.IO;
using HRManagement.Controllers;
using HRManagement.Models;
using HRManagement.Models.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HRManagement.Tests.Controllers
{
    [TestClass]
    public class HelpersTest
    {
        [TestMethod]
        public void TestUpload()
        {
            //Arrange
            string filename = "image.jpg";
            //act, normally I should mock the file system as well as the http object that carries my file to be uploaded.
          //string result = Helpers.Upload(filename);
            //ASsert
            Assert.AreEqual("","/uploads/image.jpg");
        }
        [TestMethod]
        public void TestUnzip()
        {
            //Arrange
            var basePath = @"C:/Users/Innocent/Documents/Visual Studio 2013/Projects/HRManagement";
            var zipToUpload = "zip.zip";
            var destination = "/repository";
            var result = Helpers.Unzip(basePath + "/" + zipToUpload, basePath+destination);
            Assert.AreEqual(true, result);
           
        }

       
    }
     
}
