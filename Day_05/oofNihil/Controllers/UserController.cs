using Microsoft.AspNetCore.Mvc;
using oofNihil.Models;

namespace oofNihil.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LoginControl(string userName, string passWord)
        {
            var theUser = DatabaseProcesses.LoginControl(userName, passWord);

            if (theUser != null)
            {
                var model = DatabaseProcesses.GetUser(userName);
                return View("~/Views/User/Index.cshtml", model);
            }
            else
            {
                return View("~/Views/User/FailedLogin.cshtml");
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string userName, string passWord)
        {
            var result = DatabaseProcesses.Register(userName, passWord);
            if (result)
            {
                var model = DatabaseProcesses.GetUser(userName);
                return View("~/Views/User/Index.cshtml", model);
            }
            else
            {
                ViewBag.Message = "Somethings went wrong.";
                return View("~/Views/User/FailedLogin.cshtml");
            }
            
        }
    }
}
