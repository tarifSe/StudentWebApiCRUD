using StudentWebApi_ASPCore.Models;
using StudentWebApi_ASPCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi_ASPCore.Services
{
    public interface IStudentService
    {
        List<Student> GetStudentsList();
        Student GetDetailsById(int id);
        ResponseModel SaveStudent(Student student);
        ResponseModel DeleteStudent(int id);

    }
}
