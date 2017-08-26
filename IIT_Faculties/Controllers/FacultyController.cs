using IIT_Faculties.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIT_Faculties.Controllers
{
    public class FacultyController : Controller
    {
        private IITFacultyDBContext db = new IITFacultyDBContext();

        // GET: Faculty
        public ActionResult Index()
        {
            return View();
        }

        // GET: Faculty/Details/5
        public JsonResult Details(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            return Json(faculty, JsonRequestBehavior.AllowGet);
        }

        // GET: Faculty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculty/Create
        [HttpPost]
        public ActionResult Create(Faculty faculty)
        {
            try
            {
                db.Faculties.Add(faculty);
                db.SaveChanges();
                return Json(faculty.ID);
            }
            catch
            {
                return Json(faculty);
            }
        }

        // GET: Faculty/Edit/5
        public JsonResult Edit(int id)
        {
            Faculty faculty = db.Faculties.Single(m => m.ID == id);
            return Json(faculty, JsonRequestBehavior.AllowGet);
        }

        // POST: Faculty/Edit/5
        [HttpPost]
        public ActionResult EditFaculty(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty).State = EntityState.Modified;
                db.SaveChanges();
                return Json(faculty.ID);
            }

            return Json(faculty);
        }

        // GET: Faculty/Delete/5
        /*
        public ActionResult Delete(int id)
        {
            var faculty = db.Faculties.Single(m => m.ID == id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }
        */

        // POST: Faculty/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {  
            try
            {
                var faculty = db.Faculties.Single(m => m.ID == id);
                db.Faculties.Remove(faculty);
                db.SaveChanges();
                return Json(faculty.ID);
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