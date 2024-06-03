using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();
        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult BringCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(certificate);
        }
        [HttpPost]
        public ActionResult BringCertificate(TblSertifikalarım t)
        {
            var p = repo.Find(x => x.ID == t.ID);
            p.Aciklama = t.Aciklama;    
            p.Tarih=p.Tarih;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NewCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCertificate(TblSertifikalarım p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCertificate(int id)
        {
            var s=repo.Find(x => x.ID == id);   
            repo.TDelete(s);
            return RedirectToAction("Index");   
        }
    }
}