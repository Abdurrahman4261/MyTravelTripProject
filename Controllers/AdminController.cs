using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje1.Models.Sınıflar;
namespace TravelTripProje1.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Silme(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges(); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        
        public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir", blog);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            Blog bl = c.Blogs.Find(b.ID);
            bl.Aciklama = b.Aciklama;
            bl.Baslik = b.Baslik;
            bl.BlogImage = b.BlogImage;
            bl.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yrm);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir",yorum);
        }
        public ActionResult YorumGuncelle(Yorumlar yr)
        {
            var yorum = c.Yorumlars.Find(yr.ID);
            yorum.KullaniciAdi = yr.KullaniciAdi;
            yorum.Mail = yr.Mail;
            yorum.Yorum = yr.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}