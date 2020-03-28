using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolDBEntitiesProject.Repository;
using SchoolDBEntitiesProject.Models;

namespace SchoolDBEntitiesProject.Controllers.API
{
    public class TeacherController : ApiController
    {

        private readonly ITeacher _context;
        private  SchoolDBEntitiesEntities __context = new SchoolDBEntitiesEntities();

        public TeacherController()
        {
            _context = new TeacherRepository(new SchoolDBEntitiesEntities());
        }

        public TeacherController(ITeacher __context)
        {
            _context = __context;
        }

        // GET: api/Teacher
        public IHttpActionResult Get()
        {
            try
            {
                // var foTeacher = _context.getAllTeachers();
                var foTeacher = __context.Teachers.Select(x => new
                {
                    x.TeacherId,
                    x.TeacherName,
                    Standard = new
                    {
                        x.Standard.StandardId,
                        x.Standard.StandardName
                    }
                }).ToList();
                if(foTeacher != null && foTeacher.Count > 0)
                {
                    var result = new { StatusCode = 200, Message = "Teachers are found", Status = true, Teachers = foTeacher};
                    return Json(result);
                }
                else
                {
                    var result = new { StatusCode = 400, Message = "Teachers are not found", Status = false };
                    return Json(result);
                }
            }catch(Exception ex)
            {
                var result = new { StatusCode = 500, Message = ex.ToString(), Status = false };
                return Json(result);
            }
        }

        // GET: api/Teacher/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var foTeacher = _context.getTeacher(id);
                if (foTeacher != null)
                {
                    var result = new { StatusCode = 200, Message = "Teacher is found", Status = true, Teachers = foTeacher };
                    return Json(result);
                }
                else
                {
                    var result = new { StatusCode = 400, Message = "Teacher is not found", Status = false };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                var result = new { StatusCode = 500, Message = ex.ToString(), Status = false };
                return Json(result);
            }
        }

        // POST: api/Teacher
        public IHttpActionResult Post(Teacher fiTeacher)
        {
            try
            {
                int x = _context.addTeacher(fiTeacher);
                if (x > 0)
                {
                    var result = new { StatusCode = 200, Message = "Teacher is added", Status = true, Teachers = fiTeacher };
                    return Json(result);
                }
                else
                {
                    var result = new { StatusCode = 400, Message = "Something went wrong", Status = false };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                var result = new { StatusCode = 500, Message = ex.ToString(), Status = false };
                return Json(result);
            }
        }

        // PUT: api/Teacher/5
        public IHttpActionResult Put(Teacher fiTeacher)
        {
            try
            {
                int x = _context.updateTeacher(fiTeacher);
                if (x > 0)
                {
                    var result = new { StatusCode = 200, Message = "Teachers is updated", Status = true };
                    return Json(result);
                }
                else
                {
                    var result = new { StatusCode = 400, Message = "Something went wrong", Status = false };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                var result = new { StatusCode = 500, Message = ex.ToString(), Status = false };
                return Json(result);
            }
        }

        // DELETE: api/Teacher/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int x = _context.removeTeacher(id);
                if (x > 0)
                {
                    var result = new { StatusCode = 200, Message = "Teacher is removed", Status = true};
                    return Json(result);
                }
                else
                {
                    var result = new { StatusCode = 400, Message = "Something went wrong", Status = false };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                var result = new { StatusCode = 500, Message = ex.ToString(), Status = false };
                return Json(result);
            }
        }
    }
}
