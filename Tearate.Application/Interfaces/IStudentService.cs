using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Application.DTOs;
using Tearate.Domain.Entities;

namespace Tearate.Application.Interfaces
{
    public interface IStudentService
    {
        Task<Student> AddStudentAsync(StudentDto studentDto);
        Task<Student> GetStudentByIdAsync(string studentId);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
