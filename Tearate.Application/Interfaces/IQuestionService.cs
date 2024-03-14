using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Application.DTOs;
using Tearate.Domain.Entities;

namespace Tearate.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> AddQuestionAsync(QuestionDto questionDto);
        Task<Question> GetQuestionByIdAsync(string questionId);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
    }
}
