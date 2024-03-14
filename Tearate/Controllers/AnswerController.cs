using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tearate.Application.DTOs;
using Tearate.Application.Interfaces;
using Tearate.Application.Services;
using Tearate.Domain.Entities;

namespace Tearate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer([FromBody] AnswerDto answerDto)
        {
            var createdAnswer = await _answerService.AddAnswerAsync(answerDto);

            return CreatedAtAction(nameof(AddAnswer), new { answerId = createdAnswer.AnswerID }, createdAnswer);
        }

        [HttpGet("{answerId}")]
        public async Task<IActionResult> GetAnswer(string answerId)
        {
            var answer = await _answerService.GetAnswerByIdAsync(answerId);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var answers = await _answerService.GetAllAnswersAsync();
            if (answers == null)
            {
                return NotFound();
            }
            return Ok(answers);
        }
    }
}
