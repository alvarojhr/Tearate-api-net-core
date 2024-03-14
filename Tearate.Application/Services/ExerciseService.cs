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
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Exercise> AddExerciseAsync(ExerciseDto exerciseDto)
        {
            var exercise = new Exercise
            {
                ExerciseID = Guid.NewGuid().ToString(),
                Name = exerciseDto.Name
            };

            await _exerciseRepository.AddAsync(exercise);
            return exercise;
        }

        public async Task<Exercise> GetExerciseByIdAsync(string exerciseId)
        {
            return await _exerciseRepository.GetByIdAsync(exerciseId);
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            return await _exerciseRepository.GetAllAsync();
        }
    }
}
