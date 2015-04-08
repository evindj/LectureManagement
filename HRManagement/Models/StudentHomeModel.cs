using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models
{
    public class StudentHomeModel
    {
        public int IdLecture { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String CreatedOn { get; set; }
    }
}