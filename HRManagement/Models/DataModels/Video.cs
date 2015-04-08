using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.DataModels
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ModuleId { get; set; }
        public string Path { get; set; }
        public int Duration { get; set; }
        public int Order { get; set; }

        
    }
}