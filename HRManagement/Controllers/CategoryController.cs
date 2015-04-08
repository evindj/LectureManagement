using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;

using System.Threading.Tasks;
using System.Web;
using HRManagement.Models;
using HRManagement.Models.DataModels;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace HRManagement.Controllers
{
    
    public class CategoryController : ApiController
    {

         private IHrManagementRepository _repo;
        public CategoryController(IHrManagementRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Category> Get()
        {
            IQueryable<Category> result = _repo.GetAllCategories();
            IEnumerable<Category> categories = result.ToList();
            return categories;

        }

        [Route("api/v1/Category/GetVideos/{idLecture}")]
        public IEnumerable<Module> GetVideos(int idLecture)
        {
           var lect = _repo.GetVideosByLecture(idLecture);
            return lect.ToList();
        } 

        public IEnumerable<StudentHomeModel> GetLect()
        {
            int def = 12;
            
          IEnumerable<Lecture>  list= _repo.GetLectures(def).ToList();
            List<StudentHomeModel> result = new List<StudentHomeModel>();
            foreach (var l in list)
            {
                StudentHomeModel model = new StudentHomeModel();
                model.Title = l.Title;
                model.IdLecture = l.Id;
                model.Author = l.Author;
                result.Add(model);
            }
            return result.ToList();
        }

        
            
         [HttpPost] // This is from System.Web.Http, and not from System.Web.Mvc
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = MultipartProvider();
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            var originalFileName = DeserializedFileName(result.FileData.First());

            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
             var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
             File.Move(uploadedFileInfo.FullName,uploadedFileInfo.DirectoryName +"/"+originalFileName);
             var lectureRawDirectory = uploadedFileInfo.DirectoryName ;
             string dirname = originalFileName.Split('.')[0];
             Helpers.Unzip(uploadedFileInfo.DirectoryName + "/" + originalFileName, uploadedFileInfo.DirectoryName + "/" + dirname);
            
            // R emove this line as well as GetFormData method if you're not 
            // sending any form data with your upload request
            var fileUploadObj = FormData<UploadLectureModel>(result);
             UploadLectureModel model = (UploadLectureModel) fileUploadObj;
             var currentUser = HttpContext.Current.User.Identity.GetUserId();
           Lecture lectureAdded=  Helpers.CreateLecture(_repo, lectureRawDirectory, model.IdCategory,dirname,currentUser);
             // perform my processing here.

            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
           File.Delete(uploadedFileInfo.FullName);
             int count = 0;
             foreach (var module in lectureAdded.Modules)
             {
                 foreach (var video in module.Videos)
                 {
                     count++;
                 }
             }
            var returnData = new ReturnedLectureModel()
            {
                Title = lectureAdded.Title,
                NumberModules = lectureAdded.Modules.Count,
                NumberLecons = count
            };

            
           
            return this.Request.CreateResponse(HttpStatusCode.OK, new { returnData });
        }

        // You could extract these two private methods to a separate utility class since
        // they do not really belong to a controller class but that is up to you
        private MultipartFormDataStreamProvider MultipartProvider()
        {
            var uploadFolder = "~/App_Data/Tmp/FileUploads"; // you could put this to web.config
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }

        // Extracts Request FormatData as a strongly typed model
        private object FormData<T>(MultipartFormDataStreamProvider result)
        {
            if (result.FormData.HasKeys())
            {
                var unescapedFormData = Uri.UnescapeDataString(result.FormData.GetValues(0).FirstOrDefault() ?? String.Empty);
                if (!String.IsNullOrEmpty(unescapedFormData))
                    return JsonConvert.DeserializeObject<T>(unescapedFormData);
            }

            return null;
        }

        private string DeserializedFileName(MultipartFileData fileData)
        {
            var fileName = FileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string FileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
    }

