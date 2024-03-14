using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Application.DTOs;

namespace Tearate.Application.Interfaces
{
    public interface IGptService
    {
        Task<AnswerDto> EvaluateAnswerAsync(string questionText, float points, AnswerDto answer);
    }
}
