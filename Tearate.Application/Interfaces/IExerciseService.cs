using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Application.DTOs;
using Tearate.Domain.Entities;

namespace Tearate.Application.Interfaces
{
    public interface IExerciseService
    {
        Task<Exercise> AddExerciseAsync(ExerciseDto exerciseDto);
        Task<Exercise> GetExerciseByIdAsync(string exerciseId);
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
    }
}
