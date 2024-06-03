using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;



namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db=new DbCvEntities();
        public ActionResult Index()
        {
            var degerler=db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Experience()
        {
            var deneyim=db.TblDeneyimlerim.ToList();    
            return PartialView(deneyim);

        }
        public PartialViewResult SocialMedia()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();    
            return PartialView(sosyalmedya);

        }
        public PartialViewResult Education()
        {
            var egitimler=db.TblEgitimlerim.ToList();    
            return PartialView(egitimler);

        }
        public PartialViewResult Skills()
        {
            var yetenekler=db.TblYeteneklerim.ToList();    
            return PartialView(yetenekler);

        }
        public PartialViewResult Hobby()
        {
            var hobiler=db.TblHobilerim.ToList();    
            return PartialView(hobiler);

        }
        public PartialViewResult Certificate()
        {
            var sertifikalar=db.TblSertifikalarım.ToList();    
            return PartialView(sertifikalar);

        }
        [HttpGet]
        public PartialViewResult Contact()
        {         
            return PartialView( );
        }
        [HttpPost]
        public PartialViewResult Contact(Tbliletisim t)
        {         
            t.Tarih=DateTime.Parse(DateTime.Now.ToString());
            db.Tbliletisim.Add( t );    
            db.SaveChanges();
            return PartialView();
        }

    }
}