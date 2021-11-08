using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MüşavirForum.Context;
using MüşavirForum.Models;
using System.Data.Entity;
using System.Web.Helpers;


namespace MüşavirForum.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();


      //  [OutputCache(Duration = 60)]
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
                return RedirectToAction("Index", "Forum");
            }
            var u = db.Users.ToList();
            return View();

        }

        public ActionResult Kayit()
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
                return RedirectToAction("Index", "Home");
            }


            return View();
        }


        [HttpPost]
        public ActionResult Kayit(User Users)
        {

            if (!ModelState.IsValid)
            { //checking model state

                ViewBag.successColor = "red";
                ViewBag.successMessage = "Kayıt Başarısız";
                return View();
            }
           
            if ((Request.Form.Get("Name") == "") || (Request.Form.Get("Username") == "") || (Request.Form.Get("Email") == "")
                || (Request.Form.Get("Password") == "") || (Request.Form.Get("Re_pass") == ""))
            {
                ViewBag.successColor = "red";
                ViewBag.successMessage = "Lütfen boş alan bırakmayın ! !";
                return View();
            }

            if (Request.Form.Get("Password")!= Request.Form.Get("Re_pass")) {
                ViewBag.successColor = "red";
                ViewBag.successMessage = "Şifreler aynı olmalıdır !";
                return View();
            }
            if (Request.Form.Get("Password").Length < 6)
            {
                ViewBag.successColor = "red";
                ViewBag.successMessage = "Şifre En az 6 haneli olmalıdır !";
                return View();
            }

            Random r = new Random();
            int token = r.Next();
            string HashDegeri = Crypto.SHA256(Request.Form.Get("Password"));
            //eşit mi    bool EsitMi = Crypto.VerifyHashedPassword(HashDegeri, Sifre);


            db.Users.Add(new User
            {
                Name = Convert.ToString(Request.Form.Get("Name")),
                Username = Convert.ToString(Request.Form.Get("Username")),
                Email = Convert.ToString(Request.Form.Get("Email")),
                Password = Convert.ToString(HashDegeri),
                Token = Convert.ToString(token),
                Status = Convert.ToInt32(1)
            });

            db.SaveChanges();
            ViewBag.successColor = "green";
            ViewBag.successMessage = "Kayıt Başarılı";
            return View();

        }





        public ActionResult Giris()
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
                return RedirectToAction("Index", "Home");
            }



            return View();
        }




        [HttpPost]
        public ActionResult Giris(User Users)
        {

            if (!ModelState.IsValid)
            { //checking model state

                ViewBag.successColor = "red";
                ViewBag.successMessage = "Giriş Başarısız";
                return View();
            }



            var u = db.Users.ToList();
            string HashDegeri = Crypto.SHA256(Request.Form.Get("Password"));

            var ret = u.FirstOrDefault(x => x.Username == Users.Username  && x.Password == HashDegeri);
       

            if (ret == null)
            {

                Session["Kullanici"] = "";
                Session["Sess_status"] = null;
                Session["UserId"] = "";

                ViewBag.successColor = "red";
                ViewBag.successMessage = "Giriş Başarısız";
                return View();


            }
      
                Session["Kullanici"] = Request.Form.Get("Username");
                Session["Sess_status"] = 1;
                Session["UserId"] = ret.Id;

            ViewBag.successColor = "green";
            ViewBag.successMessage = "Giriş Başarılı";
            //  return View();
            return RedirectToAction("Index", "Home");


        }


        public ActionResult Cikis()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Profil()
        {
            return View();
        }

        public ActionResult PasswordReset()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}