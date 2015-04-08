using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.IO.Compression;
using HRManagement.Models.DataModels;

namespace HRManagement.Controllers
{
    public class Helpers
    {
        //accepts the filename and returns the location where the f.
        public static string Upload(HttpPostedFileBase file, string pathBase)
        {
            var path = "";
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                 path = Path.Combine(pathBase, fileName);
                file.SaveAs(path);
                path = pathBase + "/" + fileName;
            }
            return path;
        }

        public static bool Unzip(string pathToZip, string destination)
        {
            try
            {

              // ZipFile.CreateFromDirectory(pathToZip, destination, CompressionLevel.Fastest, true);

                ZipFile.ExtractToDirectory(pathToZip, destination);
                return true;

            }
            catch (Exception)
            {
                   return false;
                
            }
            
        }

        public static Lecture CreateLecture(IHrManagementRepository repo, string directory, int category, string lectureTitle, string userId)
        {
            /*still have some work to do, check for thumbs in the folder, handle exercise file when browsing the zip*/
           
                Lecture lectureToAdd = new Lecture()
                {
                    Title = lectureTitle,
                    DateCreated = DateTime.Now,
                    CategoryId = category,
                    AspNetUserId= userId
                };
                Lecture lectureAdded=   repo.AddLecture(lectureToAdd,  userId);
                string path = "Lecture" + lectureAdded.Id;
                try
                {
                    DirectoryInfo currentDir = new DirectoryInfo(directory +"/" + lectureTitle);
                    foreach (var  dir in currentDir.GetDirectories())
                    {
                        if (!dir.Name.StartsWith("Ex"))
                        {
                            Module moduleToAdd = new Module()
                            {
                                Title = dir.Name.Split('.')[0],
                                LectureId = lectureAdded.Id

                            };
                            int i = 1;
                            foreach (var file in dir.GetFiles())
                            {
                                if (!file.Name.StartsWith("Thumbs"))
                                {

                                    Video videoToAdd = new Video()
                                    {
                                        Title = file.Name.Split('.')[0],
                                        Path = path + "/" + moduleToAdd.Title + "/" + file.Name,
                                        Order = i
                                    };
                                    i++;
                                    moduleToAdd.Videos.Add(videoToAdd);
                                }

                            }
                            lectureAdded.Modules.Add(moduleToAdd);
                        }
                    }
                    currentDir.MoveTo(directory + "/" + path);
                    if (repo.Save()) return lectureAdded;
                    else return null;
                }
            catch (Exception)
            {
                // delete lecture if exception before returning false
                if(lectureAdded!=null)
                repo.RemoveLecture(lectureAdded);
                return null;
            }
        }
    }
}