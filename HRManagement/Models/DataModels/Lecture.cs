using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models;

namespace HRManagement.Models.DataModels
{
    public class Lecture
    {
        public string Title { get; set; }
        public int Id { get; set; }
        //userid represent the user who poste the lecture(the lecturer)
        public string AspNetUserId { get; set; }
        public int TotalDuration { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Question> Questions { get; set; }
        public DateTime DateCreated { get; set; }
        public string ExerciseFiles { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }

        public Lecture()
        {
            Modules = new List<Module>();
            Questions = new List<Question>();
        }
       
    }
}