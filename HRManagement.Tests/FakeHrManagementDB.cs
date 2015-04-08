using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagement.Models.DataModels;

namespace HRManagement.Tests
{
    class FakeHrManagementDb: IHrManagementRepository
    {
        public List<Lecture> Lectures = new List<Lecture>();
        public List<Category> categories = new List<Category>()
        {
            new Category()
            {
                Title = "This is the first Category"
            }
        };
 
        public Lecture AddLecture(Lecture lecture, string userId)
        {
            Lectures.Add(lecture);
            return lecture;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void RemoveLecture(Lecture lecture)
        {
            throw new NotImplementedException();
        }

        public bool AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Lecture> GetLectures(int i)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Module> GetVideosByLecture(int idLecture)
        {
            throw new NotImplementedException();
        }
    }
}
