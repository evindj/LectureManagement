using HRManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace HRManagement.Controllers
{
    public class ExplorerController : Controller
    {
            private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ExplorerController()
        {
        }

        public ExplorerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Explorer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Confirm()
        {
            return View();
        }
        //
        // GET: /Explorer/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, ResumePath = "", DisplayName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //  await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    //Send an email with this link
                    try
                    {
                        string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        string body = System.IO.File.ReadAllText(Server.MapPath("~/EmailTemplates/ExplorerProgramEmail.html"));
                        body = body.Replace("#name#", user.UserName);
                        body= body.Replace("#callback#", callbackUrl);
                        await UserManager.SendEmailAsync(user.Id, "Confirm your account", body);
                        return RedirectToAction("Confirm", "Explorer");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                  
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


    }
}