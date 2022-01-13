using Overture.Areas.Admin.Data;
using Overture.Areas.Database;
using Overture.Areas.User.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Overture.Areas.Admin.Controllers
{
    public class AdminJQGridController : Controller
    {
        // GET: User/UserJQGrid
        // GET: JQGrid
        public JsonResult AdminGetDashboard()
        {
            var adminName = Request.Cookies["fukinAdmin"].Value;
            var model = AdminDatabaseProcesses.GetDatabase(adminName);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public string AdminAddMovie(string UserName, string MovieName, string CategoryName)
        {
            var userName = Request.Cookies["fukinAdmin"].Value;
            AdminDatabaseProcesses.AddMovie(UserName, MovieName, CategoryName);
            return $"Movie: {MovieName} added to your movie/s.";
        }

        public string AdminEditMovie(Movie oldMovInfos, AdminManageModel adminMM)
        {
            var userName = Request.Cookies["fukinAdmin"].Value;
            var result = AdminDatabaseProcesses.Update(oldMovInfos, adminMM); //LMAO

            if (result)
            {
                return $"{oldMovInfos.Name} edited as {adminMM.MovieName}.";
            }
            else{
                return $"{oldMovInfos.Name} Couldn' t edited.";
            }

        }

        public string AdminDeleteMovie(Movie IncominMovie)
        {
            var userName = Request.Cookies["fukinAdmin"].Value;
            GridProcesses.DeleteMovie(IncominMovie);
            return $"Movie: {IncominMovie.Name} Deleted from your movie/s.";
        }
    }
}