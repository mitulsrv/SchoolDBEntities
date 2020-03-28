using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDBEntitiesProject.Models;
namespace SchoolDBEntitiesProject.Repository
{
    public class TeacherRepository: ITeacher
    {
        private readonly SchoolDBEntitiesEntities _context;

        public TeacherRepository()
        {
            _context = new SchoolDBEntitiesEntities();
        }

        public TeacherRepository(SchoolDBEntitiesEntities __context)
        {
            _context = __context;
        }

        public int addTeacher(Teacher fiTeacher)
        {
            _context.Teachers.Add(fiTeacher);
            return (_context.SaveChanges());
        }

        public ICollection<Teacher> getAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teacher getTeacher(int TeacherId)
        {
            return _context.Teachers.Where(teacher => teacher.TeacherId == TeacherId).FirstOrDefault();
        }

        public int removeTeacher(int TeacherId)
        {
            var foTeacher = _context.Teachers.Where(teacher => teacher.TeacherId == TeacherId).FirstOrDefault();
            if (foTeacher != null) { 
                _context.Teachers.Remove(foTeacher);
            }
            return _context.SaveChanges();
        }

        public int updateTeacher(Teacher fiTeacher)
        {
            var foTeacher = _context.Teachers.Where(teacher => teacher.TeacherId == fiTeacher.TeacherId).FirstOrDefault();
            if(foTeacher != null)
            {
                foTeacher.TeacherName = fiTeacher.TeacherName;
                foTeacher.StandardId = fiTeacher.StandardId;
                _context.Entry(foTeacher).State = System.Data.Entity.EntityState.Modified;
            }
            return _context.SaveChanges();
        }

        private bool flgIsDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.flgIsDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.flgIsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}