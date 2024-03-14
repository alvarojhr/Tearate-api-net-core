using Tearate.Domain.Entities;

namespace Tearate.Domain.Interfaces
{
    public interface IExerciseRepository
    {
        Task<Exercise> GetByIdAsync(string id);
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task AddAsync(Exercise exercise);
    }
}
