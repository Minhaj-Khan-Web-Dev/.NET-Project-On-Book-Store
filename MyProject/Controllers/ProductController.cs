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
    [Authorize(Roles = "Admin")]
    [Authorize]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ProductController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Product


        public ActionResult Index()

        {
            Session["count"] = db.Products.Count();
            Session["ur"] = db.Registers.Count();
            Session["catcount"] = db.Categories.Count();
            Session["emp"] = db.Role_Tbls.Count();
            return View(db.Products.ToList());;
           
            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Data = db.Categories.ToList();
            return View();
        }


        [HttpPost]
      
        public ActionResult Create(Product Prod, HttpPostedFileBase file)
        {
             Random random = new Random();
            var ran = random.Next(1000000, 5000000);
            var Myrandom = "PR-" + ran;
            
            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;
            var myname = ds + ms + file.FileName;
            var path = Server.MapPath(Path.Combine("~/ProjectImages/" + myname));
            file.SaveAs(path);

            Prod.ProImage = myname;
            Prod.Product_key = Myrandom;

            db.Products.Add(Prod);
            db.SaveChanges();


            return RedirectToAction("Index");

        }
       
        public ActionResult Edit(int id)
        {
            ViewBag.Data = db.Categories.ToList();
            var data = db.Products.Find(id);
            return View(data);
            
        }


        [HttpPost]
        
        public ActionResult Edit(Product Prod, HttpPostedFileBase file)
        {

            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;
            var myname = ds + ms + file.FileName;
            var path = Server.MapPath(Path.Combine("~/ProjectImages/" + myname));
            file.SaveAs(path);

            Prod.ProImage = myname;

            db.Entry(Prod).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index");

        }
        
        public ActionResult Delete(int id)
        {

            var data = db.Products.Find(id);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}