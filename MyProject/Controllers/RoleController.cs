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
    public class RoleController : Controller
    {
        // GET: Role
        MyDbContext db = new MyDbContext();
        
        public ActionResult Index()
        {
            Session["count"] = db.Products.Count();
            Session["ur"] = db.Registers.Count();
            Session["catcount"] = db.Categories.Count();
            Session["emp"] = db.Role_Tbls.Count();
            return View(db.Role_Tbls.ToList()); ;
        }
        
        public ActionResult Create()
        {
            ViewBag.data = db.Registers.ToList();
            return View();
        }


        [HttpPost]
       
        public ActionResult Create(Role_tbl rtbl)
        {

            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;


            db.Role_Tbls.Add(rtbl);
            db.SaveChanges();


            return RedirectToAction("Index");

        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.Data = db.Registers.ToList();
            var data = db.Products.Find(id);
            return View(data);
        }


        [HttpPost]
        
        public ActionResult Edit(Role_tbl rtbl, HttpPostedFileBase file)
        {

            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;
            

            db.Entry(rtbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index");

        }
       
        public ActionResult Delete(int id)
        {

            var data = db.Role_Tbls.Find(id);
            db.Role_Tbls.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}