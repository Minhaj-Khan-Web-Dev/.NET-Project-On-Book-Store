using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;

namespace MyProject.Controllers
{
    public class RegisterController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Register
        public ActionResult Index(Register reg)
        {
            
            return View();
        }

        public ActionResult UserRegister()
        {

            return View();

        }
        [HttpPost]
        public ActionResult UserRegister(Register reg, HttpPostedFileBase file)
        {
            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;
            var myname = ds + ms + file.FileName;
            var path = Server.MapPath(Path.Combine("~/ProjectImages/" + myname));
            file.SaveAs(path);

            reg.User_img = myname;
            db.Registers.Add(reg);
            db.SaveChanges();
            return RedirectToAction("Userlogin");            
        }

        public ActionResult Userlogin()
        {



            return View();

        }
        [HttpPost]
        public ActionResult Userlogin(Register reg)
        {
            
            
            var isValid = db.Registers.Where(x => x.password == reg.password && x.user_email == reg.user_email).FirstOrDefault();
            

            if (isValid !=null)
            {

                Session["uimg"] = isValid.User_img;
                Session["name"] = isValid.username;
                FormsAuthentication.SetAuthCookie(reg.user_email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();
            }

            

        }
        public ActionResult Userlogout()
        {
           
            FormsAuthentication.SignOut();
            return RedirectToAction("Userlogin", "Register");

        }
    }
}