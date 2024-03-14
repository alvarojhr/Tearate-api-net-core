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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> AddQuestionAsync(QuestionDto questionDto)
        {
            var question = new Question
            {
                QuestionID = Guid.NewGuid().ToString(),
                ExerciseID = questionDto.ExerciseID,
                Points = questionDto.Points,
                QuestionText = questionDto.QuestionText,
            };

            await _questionRepository.AddAsync(question);
            return question;
        }

        public async Task<Question> GetQuestionByIdAsync(string questionId)
        {
            return await _questionRepository.GetByIdAsync(questionId);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllAsync();
        }
    }
}
