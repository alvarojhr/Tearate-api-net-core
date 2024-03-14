using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Domain.Entities;

namespace Tearate.Domain.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer> GetByIdAsync(string id);
        Task<IEnumerable<Answer>> GetAllAsync();
        Task AddAsync(Answer answer);

    }
}
