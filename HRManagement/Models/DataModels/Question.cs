using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace HRManagement.Models.DataModels
{
    public class Question
    {
        public int Id { get; set; }
        public string Libel { get; set; }
        public ICollection<Option> Options { get; set; }
        public int LectureId { get; set; }

        public Question()
        {
            Options = new List<Option>();
        }
    }
}