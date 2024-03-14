using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Application.DTOs;
using Tearate.Application.Interfaces;
using Tearate.Domain.Entities;
using Tearate.Domain.Interfaces;

namespace Tearate.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;            
        }

        public async Task<Student> AddStudentAsync(StudentDto studentDto)
        {
            var student = new Student
            {
                StudentID = Guid.NewGuid().ToString(),
                Name = studentDto.Name
            };

            await _studentRepository.AddAsync(student);
            return student;
        }

        public async Task<Student> GetStudentByIdAsync(string studentId)
        {
            return await _studentRepository.GetByIdAsync(studentId);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

       
    }
}
