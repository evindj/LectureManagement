using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.DataModels
{
    public class HrManagementRepository:IHrManagementRepository
    {
        private ApplicationDbContext _cxt;
      
        public HrManagementRepository(ApplicationDbContext cxt)
        {
            _cxt = cxt;
        }

        public Lecture AddLecture(Lecture lecture, string userId)
        {
            _cxt.Lectures.Add(lecture);
           var user=  _cxt.Users.FirstOrDefault(u => u.Id== userId);
           if (user != null)
           {
               user.Lectures.Add(lecture);
               // Default the Author to the UserName.
               lecture.Author = user.UserName;
           }
           else return null;
            if (Save())
                return _cxt.Lectures.OrderByDescending(l => l.Id).FirstOrDefault();
            else return null;
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
            return _cxt.Categories;
        }

        public IQueryable<Lecture> GetLectures(int i)
        {
            return _cxt.Lectures.Take(i);
        }

        public IQueryable<Module> GetVideosByLecture(int idLecture)
        {
            var result = (from module in _cxt.Modules.Include("videos") where module.LectureId == idLecture select module ) ;
            return result;

        }

        public bool Save()
        {
            try
            {
                return _cxt.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}