using Overture.Areas.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Overture.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            var model = AdminDatabaseProcesses.GetAdmin(Request.Cookies["fukinAdmin"].Value);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginControl(string userName, string passWord)
        {

            var result = AdminDatabaseProcesses.LoginControl(userName, passWord);

            if (result)
            {
                HttpCookie mfCookie = new HttpCookie("fukinAdmin", userName);
                Response.Cookies.Add(mfCookie);

                var model = AdminDatabaseProcesses.GetAdmin(userName);
                return View("~/Areas/Admin/Views/Admin/Login.cshtml", model);
            }
            else
            {
                ViewBag.ErrorMessage = "Check your login info mf.";
                return View("~/Areas/Admin/Views/Admin/Failed.cshtml");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterControl(string userName, string passWord)
        {
            var cryptedPass = Crypt.Gloria(passWord);

            var result = AdminDatabaseProcesses.Register(userName, cryptedPass, (int)Roles.RoleTypez.Admin);

            if (result)
            {
                var model = AdminDatabaseProcesses.GetAdmin(userName);
                return View("~/Areas/Admin/Views/Admin/Index.cshtml", model);
            }
            else
            {
                ViewBag.ErrorMessage = "Somethings went wrong.";
                return View("~/Areas/Admin/Views/Admin/Failed.cshtml");
            }
        }


        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult AddMovie()
        {
            return View();
        }


        public ActionResult DeleteProfile()
        {
            return View();
        }
    }
}