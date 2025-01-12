using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Helpers;

namespace MyProject.Controllers
{
   
    public class AuthController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Auth
      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            
            
           
                return View();
           
        }
        [HttpPost]
        public ActionResult Login(User_tbl user)
        {
            
            bool isValid = db.User_Tbls.Any(x =>  x.User_Passowrd == user.User_Passowrd && x.User_Email == user.User_Email);





           ;
            if (isValid)
            {
                Session["name"] = user.User_Email;
                FormsAuthentication.SetAuthCookie(user.User_Email,false);
                return View();
                ;
            }
            else
            {
               
                return View();
            }
           
        }

        public ActionResult LogOut()
        {
            Session.Remove("name");

            FormsAuthentication.SignOut();
            return View();
            
        }
    }
}