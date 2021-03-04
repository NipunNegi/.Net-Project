using BL;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public Boolean SignIn( string email, string password)
        {
            var name = new UserBL().Login(email, password);
            if (name != "" || name != null)
            {
                Session["user"] = name;
                return true;
            }
            else
                return false;
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if(ModelState.IsValid)
            {
                var response = new UserBL().AddUser(user);
                if (response == "Exist")
                    return View("UserExist");
                else if (response == "Done")
                    return View("AccountCreated"); 
            } 
            return View(user);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}