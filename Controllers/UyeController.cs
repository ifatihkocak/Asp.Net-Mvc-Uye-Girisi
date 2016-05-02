using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uyegirisuygulama.Models;

namespace Uyegirisuygulama.Controllers
{
    public class UyeController : Controller
    {
        //
        // GET: /Uye/
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(Kullanicilar Kul)
        {
            if (ModelState.IsValid)
            {
                using (UyelikEntities DB = new UyelikEntities())
                {
                    var Uyegirisi = DB.Kullanicilar.Where(U => U.Kul_AD.Equals(U.Kul_AD) && U.Kul_PAROLA.Equals(U.Kul_PAROLA)).FirstOrDefault();
                    if (Uyegirisi != null)
                    {
                        Session["GirisKullaniciID"] = Uyegirisi.Kul_ID.ToString();
                        Session["GirisKullaniciAD"] = Uyegirisi.Kul_AD.ToString();
                        return RedirectToAction("Profil");
                    }
                }
                
            }
            return View(Kul);
        }

        public ActionResult Profil()
        {
            if (Session["GirisKullaniciID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


	}
}