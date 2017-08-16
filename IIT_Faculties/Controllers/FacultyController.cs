using IIT_Faculties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIT_Faculties.Controllers
{
    public class FacultyController : Controller
    {
        private FacultyDBContext db = new FacultyDBContext();

        // GET: Faculty
        public ActionResult Index()
        {
            var faculties = from faculty in db.Faculties
                            orderby faculty.ID
                            select faculty;
            return View(faculties);
        }

        // GET: Faculty/Details/5
        public ActionResult Details(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if(faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // GET: Faculty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty faculty)
        {
            try
            {
                db.Faculties.Add(faculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(faculty);
            }
        }

        // GET: Faculty/Edit/5
        public ActionResult Edit(int id)
        {
            var faculty = db.Faculties.Single(m => m.ID == id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculty/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var faculty = db.Faculties.Single(m => m.ID == id);
                if (TryUpdateModel(faculty))
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(faculty);
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty/Delete/5
        public ActionResult Delete(int id)
        {
            var faculty = db.Faculties.Single(m => m.ID == id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
            try
            {
                var faculty = db.Faculties.Single(m => m.ID == id);
                db.Faculties.Remove(faculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetFaculties()
        {
            return Json(db.Faculties.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}