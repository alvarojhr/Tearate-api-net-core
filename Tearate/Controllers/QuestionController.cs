using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tearate.Application.DTOs;
using Tearate.Application.Interfaces;

namespace Tearate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDto questionDto)
        {
            var createdQuestion = await _questionService.AddQuestionAsync(questionDto);

            return CreatedAtAction(nameof(AddQuestion), new { questionId = createdQuestion.QuestionID }, createdQuestion);
        }

        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestion(string questionId)
        {
            var question = await _questionService.GetQuestionByIdAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            if (questions == null)
            {
                return NotFound();
            }
            return Ok(questions);
        }
    }
}
