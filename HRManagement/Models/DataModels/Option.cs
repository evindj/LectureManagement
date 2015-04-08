using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.DataModels
{
    public class Option
    {
        public string Libel { get; set; }
        public int Id { get; set; }
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
    }
}