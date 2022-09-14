using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProjee.Models.Siniflar;

namespace TravelTripProjee.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
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
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir", blog);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blog = c.Blogs.Find(b.ID);
            blog.Aciklama = b.Aciklama;
            blog.Baslik = b.Baslik;
            blog.Tarih = b.Tarih;
            blog.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var deger = c.Yorumlars.ToList();
            return View(deger);
        }
        public ActionResult YorumSil(int id)
        {
            var deger = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var deger = c.Yorumlars.Find(id);
            return View("YorumGetir", deger);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var deger = c.Yorumlars.Find(y.ID);
            deger.Kullaniciadi = y.Kullaniciadi;
            deger.Mail = y.Mail;
            deger.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult HakkimizdaListesi()
        {
            var deger = c.Hakkimizdas.ToList();
            return View(deger);
        }
        public ActionResult HakkimizdaGetir(int id)
        {
            var deger = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", deger);
        }
        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var deger = c.Hakkimizdas.Find(h.ID);
            deger.Aciklama = h.Aciklama;
            deger.FotoUrl = h.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }
        public ActionResult Iletisim()
        {
            var deger = c.Iletisims.ToList();
            return View(deger);
        }
        public ActionResult IletisimSil(int id)
        {
            var deger = c.Iletisims.Find(id);
            c.Iletisims.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }
        public ActionResult IletisimGetir(int id)
        {
            var deger = c.Iletisims.Find(id);
            return View("IletisimGetir", deger);
        }
        public ActionResult IletisimGuncelle(Iletisim i)
        {
            var deger = c.Iletisims.Find(i.ID);
            deger.AdSoyad = i.AdSoyad;
            deger.Mail = i.Mail;
            deger.Konu = i.Konu;
            deger.Mesaj = i.Mesaj;
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }
    }
}