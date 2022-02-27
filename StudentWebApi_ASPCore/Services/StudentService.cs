using StudentWebApi_ASPCore.Models;
using StudentWebApi_ASPCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi_ASPCore.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _Context;
        public StudentService(StudentContext studentContext)
        {
            _Context = studentContext;
        }

        public ResponseModel DeleteStudent(int id)
        {
            ResponseModel rm = new ResponseModel();
            try
            {
                Student student = GetDetailsById(id);
                if (student != null)
                {
                    _Context.Remove<Student>(student);
                    _Context.SaveChanges();
                    rm.IsSuccess = true;
                    rm.Message = "Student Delete Success!";
                }
                else
                {
                    rm.IsSuccess = false;
                    rm.Message = "Stu Not found";
                }
            }
            catch (Exception ex)
            {
                rm.IsSuccess = false;
                rm.Message = "Error: " + ex.Message;
            }
            return rm;
        }

        public Student GetDetailsById(int id)
        {
            Student student;
            try
            {
                student = _Context.Find<Student>(id);
            }
            catch (Exception)
            {

                throw;
            }
            return student;
        }

        public List<Student> GetStudentsList()
        {
            List<Student> students;
            try
            {
                students = _Context.Set<Student>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return students;
        }

        public ResponseModel SaveStudent(Student student)
        {
            ResponseModel rm = new ResponseModel();
            try
            {
                Student _student = GetDetailsById(student.Id);
                if (_student != null)
                {
                    _student.Name = student.Name;
                    _student.Roll = student.Roll;
                    _student.Class = student.Class;

                    _Context.Update<Student>(_student);
                    rm.Message = "Updated!";
                }
                else
                {
                    _Context.Add<Student>(student);
                    rm.Message = "Saved";
                }
                _Context.SaveChanges();
                rm.IsSuccess = true;
            }
            catch (Exception e)
            {
                rm.IsSuccess = false;
                rm.Message = "Err: " + e.Message;
               
            }
            return rm;
        }
    }
}
