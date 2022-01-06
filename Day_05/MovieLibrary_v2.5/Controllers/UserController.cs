using MovieLibrary_v2._5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLibrary_v2._5.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string userName, string passWord)
        {
            var cryptPassword = CryptEm.Gloria(passWord);
            var registerAttempt = DBProcesses.Register(userName, cryptPassword, (int)Rolez.RoleTypez.User);

            var model = DBProcesses.GetUserIntel(userName);

            if (registerAttempt)
            {
                return View("~/Views/User/Login.cshtml", model);
            }
            else
            {
                return View("~/Views/User/FailedLogin.cshtml", model);
            }

            
        }

        public ActionResult LoginControl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginControl(string userName, string passWord)
        {
            HttpCookie daCooky = new HttpCookie("fukinUser", userName);
            Response.Cookies.Add(daCooky);
            var cryptPassword = CryptEm.Gloria(passWord);
            var loginAttemptResult = DBProcesses.LoginControl(userName, cryptPassword);

            var model = DBProcesses.GetUserIntel(userName);

            if (loginAttemptResult)
            {
                return View("~/Views/User/Index.cshtml", model);
            }
            else
            {
                return View("~/Views/User/FailedLogin.cshtml", model);
            }
            
        }

        public ActionResult Profile()
        {
            var fukUser = Request.Cookies["fukinUser"].Value;
            var model = DBProcesses.GetUserIntel(fukUser);

            if (model != null)
            {
                return View("~/Views/User/Profile.cshtml", model);
            }
            else
            {
                return View("~/Views/User/FailedLogin.cshtml", model);
            }

            
        }

        [HttpPost]
        public ActionResult Profile(string Username, string firstName, string lastName, string EMail, string passWord, HttpPostedFileBase file)
        {
            var pFileName = "";

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                if (extension == ".jpg" || extension == ".png")
                {

                    var fileName = Path.GetFileName(file.FileName);
                    pFileName = fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/UserPics"), fileName);

                    file.SaveAs(path);

                    DBProcesses.UpdateUser(Username, passWord, firstName, lastName, EMail, pFileName);
                }
                else
                {
                    ViewData["Message"] = "Please select a picture file.";
                }

            }
            //else
            //{
            //    var currentSettings = DatabaseProcesses.GetUser(Username);
            //    DatabaseProcesses.UpdateUser(Username, passWord, firstName, lastName, EMail, currentSettings.ProfilePic);
            //}

            var model = DBProcesses.GetUserIntel(Username);


            return View(model);

        }


        public ActionResult DeleteProfile(string userName)
        {
            var deleteAttempt = DBProcesses.DeleteUser(userName);
            if (deleteAttempt)
            {
                return View("~/Views/User/Login.cshtml");
            }
            else
            {
                var model = DBProcesses.GetUserIntel(userName);
                return View("~/Views/User/Index.cshtml", model);
            }
            
        }

        public ActionResult Dashboard()
        {
            var model = DBProcesses.GetUserIntel("Gloria");
            return View(model);
        }



        //MOVIE PROCESSES


        public ActionResult AddMovie()
        {
            var model = DBProcesses.GetUserIntel("Gloria");
            return View(model);
        }

        [HttpPost]
        public ActionResult AddMovie(string movieName, string userName)
        {
            var theFUser = DBProcesses.GetUserIntel(userName);

            if (theFUser != null)
            {
                var addMovieAttempt = DBProcesses.AddMovie(movieName, theFUser);
                if (addMovieAttempt)
                {
                    var model = DBProcesses.GetUserIntel(userName);
                    return View("~/Views/User/Index.cshtml", model);
                }
                else
                {
                    var model = DBProcesses.GetUserIntel(userName);
                    return View("~/Views/User/LMAO.cshtml", model);
                }
            }
            else
            {
                var model = DBProcesses.GetUserIntel(userName);
                return View("~/Views/User/LMAO.cshtml", model);
            }
        }
    }
}