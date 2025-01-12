using MyProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace MyProject.Controllers
{
    [Authorize]
    [OutputCache(NoStore = true, Duration = 0)]
    public class CategoryController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Category
        [Authorize(Roles = "Admin")]
        public ActionResult Index()

        {
            Session["count"] = db.Products.Count();
            Session["ur"] = db.Registers.Count();
            Session["catcount"] = db.Categories.Count();
            Session["emp"] = db.Role_Tbls.Count();
            return View(db.Categories.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Category cat, HttpPostedFileBase file)
        {

            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;
            var myname = ds + ms + file.FileName;
            var path = Server.MapPath(Path.Combine("~/ProjectImages/" + myname));
            file.SaveAs(path);

            cat.CatImage = myname;

            db.Categories.Add(cat);
            db.SaveChanges();


            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Category cat, HttpPostedFileBase file)
        {

            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;
            var myname = ds + ms + file.FileName;
            var path = Server.MapPath(Path.Combine("~/ProjectImages/" + myname));
            file.SaveAs(path);

            cat.CatImage = myname;

            db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            
            var data = db.Categories.Find(id);
            db.Categories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }


    }
}