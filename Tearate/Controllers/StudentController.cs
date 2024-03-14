using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tearate.Application.DTOs;
using Tearate.Application.Interfaces;
using Tearate.Domain.Entities;

namespace Tearate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            var createdStudent = await _studentService.AddStudentAsync(studentDto);

            return CreatedAtAction(nameof(GetStudent), new { studentId = createdStudent.StudentID }, createdStudent);
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(string studentId)
        {
            var student = await _studentService.GetStudentByIdAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetAllStudentsAsync();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }
    }
}
