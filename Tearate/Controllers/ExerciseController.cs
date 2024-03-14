using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tearate.Application.DTOs;
using Tearate.Application.Interfaces;

namespace Tearate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise([FromBody] ExerciseDto exerciseDto)
        {
            var createdExercise = await _exerciseService.AddExerciseAsync(exerciseDto);

            return CreatedAtAction(nameof(AddExercise), new { exerciseId = createdExercise.ExerciseID }, createdExercise);
        }

        [HttpGet("{exerciseId}")]
        public async Task<IActionResult> GetExercise(string exerciseId)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(exerciseId);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var exercises = await _exerciseService.GetAllExercisesAsync();
            if (exercises == null)
            {
                return NotFound();
            }
            return Ok(exercises);
        }
    }
}
