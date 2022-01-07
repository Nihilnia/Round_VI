using Overture.Areas.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Overture.Areas.User.Controllers
{
    public class UserJQGridController : Controller
    {
        // GET: User/UserJQGrid
        // GET: JQGrid
        public JsonResult GetDashboard()
        {
            var userName = Request.Cookies["fukinUser"].Value;
            var model = GridProcesses.GETMFGET(userName);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public string AddMovie(Movie Movie)
        {
            var userName = Request.Cookies["Username"].Value;
            GridProcesses.AddMovie(userName, Movie.Name);
            return $"Added {Movie.Name} to your movie/s.";
        }

        public string DeleteMovie(Movie Movie)
        {
            var userName = Request.Cookies["Username"].Value;
            GridProcesses.DeleteMovie(Movie.Name);
            return $"Deleted from your movie/s.";
        }

        public string EditMovie(Movie Movie)
        {
            var userName = Request.Cookies["Username"].Value;
            GridProcesses.UpdateMovie(Movie.Name); //LMAO
            return $"edited.";
        }
    }
}