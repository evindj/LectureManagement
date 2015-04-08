using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.DataModels
{
    public class Module
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public string Title { get; set; }
        public ICollection<Video> Videos { get; set; }

        public Module()
        {
            Videos= new List<Video>();
        }
    }
}