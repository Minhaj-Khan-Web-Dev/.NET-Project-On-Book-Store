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
    public class UsersController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Users
       
        public ActionResult Index()
        {
            return View(db.User_Tbls.ToList()); ;
        }

        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(User_tbl utbl)
        {

            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;
           

            db.User_Tbls.Add(utbl);
            db.SaveChanges();


            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            
            var data = db.User_Tbls.Find(id);
            return View(data);
        }


        [HttpPost]
        public ActionResult Edit(User_tbl utbl, HttpPostedFileBase file)
        {

            var ds = DateTime.Now.Second.ToString();
            var ms = DateTime.Now.Millisecond.ToString();


            ViewBag.ds = ds;
            ViewBag.ms = ms;


            db.Entry(utbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {

            var data = db.User_Tbls.Find(id);
            db.User_Tbls.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}