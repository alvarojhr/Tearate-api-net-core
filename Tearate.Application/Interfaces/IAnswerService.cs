using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Application.DTOs;
using Tearate.Domain.Entities;

namespace Tearate.Application.Interfaces
{
    public interface IAnswerService
    {
        Task<Answer> AddAnswerAsync(AnswerDto answerDto);
        Task<Answer> GetAnswerByIdAsync(string answerId);
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
    }
}
