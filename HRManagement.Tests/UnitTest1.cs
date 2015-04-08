using System;
using HRManagement.Controllers;
using HRManagement.Models.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 
 the user */
namespace HRManagement.Tests
{
    [TestClass]
    public class TestUpload
    {
        [TestMethod]
        public void TestUploadLecture()
        {
            var fakeLectureInput = new FakeLectureInput();
            var lectureToAdd = fakeLectureInput.GenerateLecture();
            var fakeDb = new FakeHrManagementDb();
            int numberbefore = fakeDb.Lectures.Count;
            fakeDb.AddLecture(lectureToAdd,"toto");
            Assert.AreEqual(numberbefore,fakeDb.Lectures.Count);

        }

        [TestMethod]
        public void TestGetCategories()
        {
            var fakeDB = new FakeHrManagementDb();
           Assert.IsFalse(0>fakeDB.categories.Count);
        }

       
    }

    
}
