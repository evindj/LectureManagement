using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Models.DataModels
{
   public  interface IHrManagementRepository
    {
        Lecture AddLecture(Lecture lecture, string userId);
       bool Save();
       void RemoveLecture(Lecture lecture);
        bool AddCategory(Category category);
       IQueryable<Category>  GetAllCategories();

       IQueryable<Lecture> GetLectures(int i);
       IQueryable<Module> GetVideosByLecture(int idLecture);



    }

}
