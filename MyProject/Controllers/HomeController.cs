using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Xml.Linq;
using MyProject.extars;

namespace MyProject.Controllers
{

    public class HomeController : Controller

    {

        MyDbContext db = new MyDbContext();
        // GET: Home

        public ActionResult Index()
        {


            ViewBag.CatData = db.Categories.ToList();
            ViewBag.Pro = db.Products.ToList();
            return View();
        }


        public ActionResult CatWise(int Id)
        {
            var data = db.Products.Where(x => x.Cid == Id).ToList();
            return View(data);
        }

        public ActionResult Details(int Id)
        {
            ViewBag.reve = db.Reviews.ToList();
            ViewBag.ID = Id;
            var data = db.Products.Where(x => x.ProId == Id).ToList();
            return View(data);
        }
        [HttpPost]

        public ActionResult Details(int Id, Review rev)
        {

            rev.Date = DateTime.Now.ToString();
            rev.Productid = Id;
            db.Reviews.Add(rev);

            db.SaveChanges();

            return RedirectToAction("Details");
        }

        public ActionResult Feedback()
        {
            if (Session["name"] !=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Userlogin", "Register");
            }
           
        }

        [HttpPost]
        public ActionResult feedback(FAQ f)
        {
           
                db.FAQs.Add(f);
                db.SaveChanges();
                return View();
            
            
            
        }
        [HttpPost]
        
        public JsonResult addtocart(int id)
        {
            if (Session["cart"] != null)
            {
                List<cart> mainlist = (List<cart>)Session["cart"];
                int check = 0;
                foreach (var item in mainlist)
                {
                    if (item.pid == id)
                    {
                        item.qty = item.qty + 1;
                        check = 0;
                        break;
                    }
                    else
                    {
                        check = 1;
                    }

                }
                if (check == 1)
                {
                    cart obj = new cart();
                    obj.pid = id;
                    obj.qty = 1;
                    mainlist.Add(obj);
                    Session["cart"] = (List<cart>)mainlist;
                }
            }
            else
            {
                List<cart> firstlist = new List<cart>();
                cart obj = new cart();
                obj.pid = id;
                obj.qty = 1;
                firstlist.Add(obj);
                Session["cart"] = (List<cart>)firstlist;
            }

            return Json(Session["cart"], JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult viewcart()
        {
            List<cart> mainlist = (List<cart>)Session["cart"];
            List<viewcart> viewlist = new List<viewcart>();
            foreach (var item in mainlist)
            {
                viewcart obj = new viewcart();
                Product pro = db.Products.Where(x => x.ProId == item.pid).FirstOrDefault();
                obj.pid = pro.ProId;
                obj.pname = pro.ProName;
                obj.qty = item.qty;
                obj.pimage = pro.ProImage;
                obj.uprice = pro.ProPrice;
                obj.totalprice = Convert.ToString(item.qty * Convert.ToDouble(pro.ProPrice));
                viewlist.Add(obj);
            }


            return View(viewlist);
        }

       
       
        public ActionResult incrs_cart(int id)
        {
            List<cart> mainlist = (List<cart>)Session["cart"];
            int qty = 0;
            for (int i = 0; i < mainlist.Count; i++)
            {
                if (mainlist[i].pid==id)
                {
                    mainlist[i].qty = mainlist[i].qty + 1;
                    qty = mainlist[i].qty;
                    break;
                }
            }
            Session["cart"] = (List<cart>) mainlist;
            return Json(qty, JsonRequestBehavior.AllowGet);
        }
        
             public ActionResult dcrs_cart(int id)
        {
            List<cart> mainlist = (List<cart>)Session["cart"];
            int qty = 0;
            for (int i = 0; i < mainlist.Count; i++)
            {
                if (mainlist[i].pid == id)
                {
                    if (mainlist[i].qty>1)
                    {
                        mainlist[i].qty = mainlist[i].qty - 1;
                        qty = mainlist[i].qty;
                        break;
                    }
                    else
                    {
                        qty = 1;
                        break;
                    }
                   
                }
            }
            Session["cart"] = (List<cart>)mainlist;
            return Json(qty, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult proceedToCheckOut()
        {
            if (Session["name"] != "" && Session["name"] != null)
            {
                
                string uqid = DateTime.Now.ToString("ddMMyyyymmssfff");
                Session["crnt_cart_id"] = uqid;
                List<cart> mainlist = (List<cart>)Session["cart"];
                for (int i = 0; i < mainlist.Count; i++)
                {
                    tbl_cart crt = new tbl_cart();
                    crt.cart_id = uqid;
                    crt.fk_Productid = mainlist[i].pid;
                    crt.qty = mainlist[i].qty;
                    db.tbl_Carts.Add(crt);
                    db.SaveChanges();

                }
                return View();
            }
            else
            {


               return RedirectToAction("Userlogin", "Register");
               
            }
            
        }
        [HttpPost]
        public ActionResult proceedToCheckOut(tbl_user_info user_Info)
        {
            if (Session["name"] != null)
            {
                user_Info.UserOrdered = (Session["name"]).ToString();
                db.tbl_User_Infos.Add(user_Info);
                db.SaveChanges();



                return RedirectToAction("ConfirmOrder");
            }
            else
            {    
                return RedirectToAction("Userlogin", "Register");
            }
            
        }










        public ActionResult ConfirmOrder()
        {
            string cart_id = Session["crnt_cart_id"].ToString();


            List<tbl_cart> mnlst = db.tbl_Carts.Where(x => x.cart_id == cart_id).ToList();
            List<prdt> product_list = new List<prdt>();
            string total_amount = "";
            for (int i = 0; i < mnlst.Count; i++)
            {
                int uuiiidd = Convert.ToInt32(mnlst[i].fk_Productid);
                Product obj = db.Products.Where(x => x.ProId == uuiiidd).FirstOrDefault();
                prdt singprdt = new prdt();
                singprdt.id = i + 1;
                singprdt.prdtname = obj.ProName;
                singprdt.pricexqty = Convert.ToString((obj.ProPrice) * mnlst[i].qty);
                singprdt.qty = mnlst[i].qty;
                product_list.Add(singprdt);
            }
            foreach (var item in product_list)
            {
                total_amount = Convert.ToString(total_amount + Convert.ToInt32(item.pricexqty));
            }
            cnfrmorder order = new cnfrmorder();
            order.products = product_list;
            order.totalAmount = total_amount;

            return View(order);
        }

        public ActionResult PlaceOrder()
        {
            string cart_id = Session["crnt_cart_id"].ToString();
            string uqid = DateTime.Now.ToString("ddMMyyyymmssfff");
            string uid = (Session["name"]).ToString();
             string totalAmount = "";
            List < tbl_cart > cart = db.tbl_Carts.Where(x => x.cart_id == cart_id).ToList();
            foreach (var item in cart)
            {
                int uuiiidd = Convert.ToInt32(item.fk_Productid);
                Product obj = db.Products.Where(x => x.ProId == uuiiidd).FirstOrDefault();
                totalAmount = Convert.ToString((totalAmount)+(obj.ProPrice) * item.qty);

            }
            order_tbl order = new order_tbl();
            order.order_no = uqid;
            order.fk_cart = cart_id;
            order.fk_tbl_u = uid;
            order.total_price = totalAmount;
            db.order_Tbls.Add(order);

            
            db.SaveChanges();
            return RedirectToAction("MyOrders");
        }
        
        public ActionResult MyOrders() {
            if (Session["name"] != null)
            {
                object n = Session["name"];
                ViewBag.naam = db.order_Tbls.Where(x => x.fk_tbl_u == n);
                return View();
            }
            else
            {
                return RedirectToAction("Userlogin", "Register");
            }
            
        }

        public ActionResult FAR()
        {
            return View(db.FAQs.ToList());
        }
        
    }
}