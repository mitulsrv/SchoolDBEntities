using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolDBEntitiesProject.Models;
namespace SchoolDBEntitiesProject.Controllers
{
    public class StandardController : Controller
    {
        private SchoolDBEntitiesProject.Models.SchoolDBEntitiesEntities foEntities = new SchoolDBEntitiesEntities();
        // GET: Standard
        public ActionResult Index()
        {
            var foStandard = foEntities.Standards.SqlQuery("SELECT * FROM Standard ORDER BY StandardName ASC").ToList();
            return View(foStandard);
        }

        // GET: Standard/Details/5
        public ActionResult Details(int id)
        {
            Standard foStandard = foEntities.Standards.Find(id);
            return View(foStandard);   
        }

        // GET: Standard/Create
        public ActionResult Create()
        {
            Standard foStandard = new Standard();
            return View(foStandard);

            
        }

        // POST: Standard/Create
        [HttpPost]
        public ActionResult Create(Standard foStandard)
        {
            try
            {
                using (var ctx = new SchoolDBEntitiesEntities())
                {
                    var fiStandard = new Standard()
                    {
                        StandardName = foStandard.StandardName,
                        Description = foStandard.Description
                    };
                    ctx.Standards.Add(fiStandard);
                    ctx.SaveChanges();
                }

                return RedirectToAction("Index", "Standard");
            }
            catch
            {
                return View("Index", "Standard");
            }
        }

        // GET: Standard/Edit/5
        public ActionResult Edit(int id)
        {
            Standard foStandard = foEntities.Standards.Find(id);
            return View(foStandard);
        }

        // POST: Standard/Edit/5
        [HttpPost]
        public ActionResult Edit(Standard foStandard)
        {
            try
            {
                var lsStandard = foEntities.Standards.Where(x => x.StandardId == foStandard.StandardId).FirstOrDefault();
                if (lsStandard != null) {
                    lsStandard.StandardName = foStandard.StandardName;
                    lsStandard.Description = foStandard.Description;
                    lsStandard.StandardId = foStandard.StandardId;
                    foEntities.Entry(lsStandard).State = System.Data.Entity.EntityState.Modified;
                    foEntities.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Standard/Delete/5
        public ActionResult Delete(int id)
        {
            var lsStandard = foEntities.Standards.Where(x => x.StandardId == id).FirstOrDefault();
            foEntities.Standards.Remove(lsStandard);
            foEntities.Entry(lsStandard).State = System.Data.Entity.EntityState.Deleted;
            foEntities.SaveChanges();
            return RedirectToAction("index", "standard");
        }

        // POST: Standard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
