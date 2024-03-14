using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tearate.Domain.Interfaces;
using Tearate.Domain.Entities;

namespace Tearate.Infraestructure.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DynamoDBContext _context;

        public QuestionRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task AddAsync(Question question)
        {
            await _context.SaveAsync(question);
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();

            var allQuestions = new List<Question>();
            var asyncSearch = _context.ScanAsync<Question>(conditions);

            while (!asyncSearch.IsDone)
            {
                var batch = await asyncSearch.GetNextSetAsync();
                allQuestions.AddRange(batch);
            }

            return allQuestions;
        }

        public async Task<Question> GetByIdAsync(string id)
        {
            return await _context.LoadAsync<Question>(id);
        }
    }
}
