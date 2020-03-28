using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolDBEntitiesProject.Repository;
using SchoolDBEntitiesProject.Models;

namespace SchoolDBEntitiesProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacher _teacherRepository;
        private readonly SchoolDBEntitiesEntities _context = new SchoolDBEntitiesEntities();

        public TeacherController()
        {
            _teacherRepository = new TeacherRepository(new SchoolDBEntitiesEntities()); //passed school db entities
        }

        public TeacherController(ITeacher __teacherRepository)
        {
            _teacherRepository = __teacherRepository;
        }

        // GET: Teacher
        public ActionResult Index()
        {
            var foTeacherList = _teacherRepository.getAllTeachers();
            return View(foTeacherList);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            var teacher = _teacherRepository.getTeacher(id);
            return View(teacher);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            Teacher foTeacher = new Teacher();
            ViewBag.ddlStandard = _context.Standards.Select(x => new SelectListItem { Text = x.StandardName, Value = x.StandardId.ToString() }).ToList();
            return View(foTeacher);
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher foTeacher)
        {
            try
            {
                // TODO: Add insert logic here
                _teacherRepository.addTeacher(foTeacher);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = _teacherRepository.getTeacher(id);
            ViewBag.ddlStandard = _context.Standards.Select(x => new SelectListItem { Text = x.StandardName, Value = x.StandardId.ToString() }).ToList();
            return View(teacher);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(Teacher foTeacher)
        {
            try
            {
                // TODO: Add update logic here
                _teacherRepository.updateTeacher(foTeacher);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            _teacherRepository.removeTeacher(id);
            return RedirectToAction("Index", "Teacher");
        }

        // POST: Teacher/Delete/5
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
