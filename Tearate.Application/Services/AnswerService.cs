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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IGptService _gptService;
        public AnswerService(IAnswerRepository answerRepository, IQuestionRepository questionRepository, IGptService gptService)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _gptService = gptService;
        }

        public async Task<Answer> AddAnswerAsync(AnswerDto answerDto)
        {
            var question = await _questionRepository.GetByIdAsync(answerDto.QuestionID);

            var evaluatedAnswer = await _gptService.EvaluateAnswerAsync(question.QuestionText, question.Points, answerDto);

            var answer = new Answer
            {
                AnswerID = Guid.NewGuid().ToString(),
                Feedback = answerDto.Feedback,
                QuestionID = answerDto.QuestionID,
                Rate = answerDto.Rate,
                Response = answerDto.Response,
                StudentID = answerDto.StudentID
            };

            await _answerRepository.AddAsync(answer);
            return answer;
        }

        public async Task<Answer> GetAnswerByIdAsync(string answerId)
        {
            return await _answerRepository.GetByIdAsync(answerId);
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            return await _answerRepository.GetAllAsync();
        }
    }
}
