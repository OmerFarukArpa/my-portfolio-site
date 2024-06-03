using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SocialMedia : Controller
    {
        GenericRepository<TblSosyalMedya> repo=new GenericRepository<TblSosyalMedya> ();


        public ActionResult Index()
        {
            var data = repo.List();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Add(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BringPage(int id)
        {
            var adress = repo.Find(x=>x.ID==id);   
            return View(adress); 
        }
        [HttpPost]
        public ActionResult BringPage(TblSosyalMedya p)
        {
            var k= repo.Find(x => x.ID ==p.ID);
            k.Ad=p.Ad;
            k.Durum=true;
            k.Link=p.Link;  
            k.ikon=p.ikon;
            repo.TUpdate(k);
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var adress=repo.Find(x=> x.ID==id);
            adress.Durum=false;
            repo.TUpdate(adress);
            return RedirectToAction("Index");
        }
    }
}