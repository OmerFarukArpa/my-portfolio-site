using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;



namespace MvcCv.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYeteneklerim> repo=new GenericRepository<TblYeteneklerim> ();  
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult NewSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkills(TblYeteneklerim p)
        {
            repo.TAdd (p);

            return RedirectToAction("Index");
        }
        
        public ActionResult RemoveSkills(int id)
        {
           var skills = repo.Find(x => x.ID == id);
            repo.TDelete(skills);
            return RedirectToAction("Index");
             
        }

        [HttpGet]
        public ActionResult EditSkills(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);

            return View(t);
        }

        [HttpPost]
        public ActionResult EditSkills(TblYeteneklerim p)
        {

            TblYeteneklerim t = repo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;            
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}