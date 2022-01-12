using Overture.Areas.Database;
using Overture.Areas.User.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Overture.Areas.Admin.Controllers
{
    public class UserJQGridController : Controller
    {
        // GET: User/UserJQGrid
        // GET: JQGrid
        public JsonResult AdminGetDashboard()
        {
            var adminName = Response.Cookies["fukinAdmin"].Value;
            var model = AdminDatabaseProcesses.GetAdminIntel();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public string AdminAddMovie(string MovieName, string CategoryName)
        {
            var userName = Request.Cookies["fukinAdmin"].Value;
            AdminDatabaseProcesses.AddMovie(userName, MovieName, CategoryName);
            return $"Added {MovieName} to your movie/s.";
        }

        public string AdminDeleteMovie(Movie IncominMovie)
        {
            var userName = Request.Cookies["fukinAdmin"].Value;
            GridProcesses.DeleteMovie(IncominMovie);
            return $"Deleted from your movie/s.";
        }

        public string AdminEditMovie(Movie IncominMovie, GridModel IncominModel)
        {
            var userName = Request.Cookies["fukinAdmin"].Value;
            var temp = IncominMovie.Name;
            GridProcesses.UpdateMovie(IncominMovie, IncominModel); //LMAO
            return $"{temp} edited.";
        }
    }
}