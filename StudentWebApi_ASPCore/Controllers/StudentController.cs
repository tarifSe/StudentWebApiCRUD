using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi_ASPCore.Models;
using StudentWebApi_ASPCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi_ASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllStudent()
        {
            try
            {
                var student = _studentService.GetStudentsList();
                if (student == null) return NotFound();
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetStudentDetailsById(int id)
        {
            try
            {
                var student = _studentService.GetDetailsById(id);
                if (student == null) return NotFound();
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var student = _studentService.DeleteStudent(id);
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveStudent(Student student)
        {
            try
            {
                var _student = _studentService.SaveStudent(student);
                return Ok(_student);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
