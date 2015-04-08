using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HRManagement.Controllers
{
    [Authorize]
    public class LectureController : Controller
    {
        private IHrManagementRepository _repo;
        public LectureController(IHrManagementRepository repo)
        {
            _repo = repo;
        }
        // GET: Lecture
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            IQueryable<Category> result = _repo.GetAllCategories();
            IEnumerable<Category> categories = result.ToList();
            //get all categories and generate the JSon
            return View();
        }
    }
}