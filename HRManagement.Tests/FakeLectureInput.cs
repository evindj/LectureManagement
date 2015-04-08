using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagement.Models.DataModels;

namespace HRManagement.Tests
{
   public class FakeLectureInput
    {
        public Lecture GenerateLecture()
        {
            var result = new Lecture()
            {
                Modules = new List<Module>()
                {
                    new Module()
                    {
                        Title = "Module1",
                    },
                    new Module()
                    {
                        Title = "Module2",
                    },
                    new Module()
                    {
                        Title = "Module3",
                    }
                },
                Title = "I am Davido"
            };
            return result;
        }
    }
}
