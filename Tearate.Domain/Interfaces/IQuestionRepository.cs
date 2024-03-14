using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Domain.Entities;

namespace Tearate.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetByIdAsync(string id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task AddAsync(Question question);
    }
}
