using Tearate.Domain.Entities;

namespace Tearate.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(string id);
        Task AddAsync(Student student);
        Task<IEnumerable<Student>> GetAllAsync();
    }
}
