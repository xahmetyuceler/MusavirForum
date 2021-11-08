using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MüşavirForum.Context;
using MüşavirForum.Models;
using System.Data.Entity;

namespace MüşavirForum.Controllers
{
    public class ForumController : Controller
    {

        DatabaseContext db = new DatabaseContext();

        // GET: Forum
        public ActionResult Index()
        {
            if (Session["Sess_status"] == null)
            {
                ViewBag.Sess_sta = Session["Sess_status"];
                ViewBag.Kullanici = "";
            }
            else
            {
                ViewBag.Sess_sta = Session["Sess_status"];
                ViewBag.Kullanici = Session["Kullanici"];
            }


       
            //Sıralama , görüntüleme , konu
            var ct = db.Categories.ToList();
            ViewData["Categories"] = ct.Where(n => n.Status == 1 ); 

            return View();
        }

        [HttpGet]
        public ActionResult Kategori(String Id)
        {
            return Content(Convert.ToString(Id));
            var ct = db.Categories.ToList().Where(n => n.Seo == Kat);
            /*
                        foreach (Category ct2 in ct)
                        {
                            var Cats = ct2.CategoryId;
                        }


                        var tp = db.Topics.ToList();
                        ViewData["Topics"] = tp.Where(n => n.Status == 1 && n.CategoryId == CategoryId );

                        return View();*/
        }

        public ActionResult Detay()
        {


            return View();
        }


        public ActionResult KonuEkle()
        {


            return View();
        }

    }
}