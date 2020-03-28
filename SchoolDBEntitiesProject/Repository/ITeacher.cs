using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolDBEntitiesProject.Models;
namespace SchoolDBEntitiesProject.Repository
{
    public interface ITeacher
    {
        ICollection<Teacher> getAllTeachers();
        Teacher getTeacher(int TeacherId);
        int addTeacher(Teacher fiTeacher);
        int updateTeacher(Teacher fiTeacher);
        int removeTeacher(int TeacherId);
    }
}
