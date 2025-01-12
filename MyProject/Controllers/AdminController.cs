using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.IO;
using System.Web.Security;
using MyProject.Models;
using System.Data.SqlClient;

namespace MyProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize]

    [OutputCache(NoStore = true, Duration = 0)]

    

    public class AdminController : Controller
    {
        // GET: Admin
       
        MyDbContext db = new MyDbContext();
        
        public ActionResult Index(Register reg)
        {
            Session["count"] = db.Products.Count();
            Session["ur"] = db.Registers.Count();
            Session["catcount"] = db.Categories.Count();
            Session["emp"] = db.Role_Tbls.Count();

            return View();
        }

        public ActionResult rev()
        {
            Session["count"] = db.Products.Count();
            Session["ur"] = db.Registers.Count();
            Session["catcount"] = db.Categories.Count();
            Session["emp"] = db.Role_Tbls.Count();
            return View(db.Reviews.ToList());
        }

        

        public ActionResult Userlist(Register reg)
        {

            return View(db.Registers.ToList());
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

            var myname = ds + ms + file.FileName;

			
			var path = Server.MapPath(Path.Combine("~/ProjectImages/" + myname));
            file.SaveAs(path);
            ViewBag.ds = ds;
            ViewBag.ms = ms;
            reg.User_img = myname;
            db.Registers.Add(reg);
            db.SaveChanges();
            return RedirectToAction("Userlist");
        }

        public ActionResult Edit(int id)
        {
            var data = db.Registers.Find(id);
            return View(data);
            

        }
        [HttpPost]

        public ActionResult Edit(Register reg, HttpPostedFileBase file)
        {
            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();

            var myname = ds + ms + file.FileName;


            var path = Server.MapPath(Path.Combine("~/ProjectImages/" + myname));
            file.SaveAs(path);
            ViewBag.ds = ds;
            ViewBag.ms = ms;
            reg.User_img = myname;
            db.Entry(reg).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Userlist");
        }


        public ActionResult Delete(int id)
        {

            var data = db.Registers.Find(id);
            db.Registers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Userlist");

        }

        public ActionResult FAQ(FAQ f) {
            

            return View(db.FAQs.ToList());
        }
        
        public ActionResult FAQEDIT(int id)
        {

            var data = db.FAQs.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult FAQEDIT(FAQ f)
        {

            db.Entry(f).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("FAQ");
        }
        public ActionResult AdminOrder(order_tbl or)
        {
            return View(db.order_Tbls.ToList()); 
        }

        public ActionResult OEdit(int id)
        {
            var data = db.order_Tbls.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult OEdit(order_tbl or)
        {

       
            db.Entry(or).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("AdminOrder");

        }
    }
}