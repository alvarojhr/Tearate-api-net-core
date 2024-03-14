using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Tearate.Domain.Entities;
using Tearate.Domain.Interfaces;

namespace Tearate.Infraestructure.Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DynamoDBContext _context;

        public AnswerRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task AddAsync(Answer answer)
        {
            await _context.SaveAsync(answer);
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();

            var allAnswers= new List<Answer>();
            var asyncSearch = _context.ScanAsync<Answer>(conditions);

            while (!asyncSearch.IsDone)
            {
                var batch = await asyncSearch.GetNextSetAsync();
                allAnswers.AddRange(batch);
            }

            return allAnswers;
        }

        public async Task<Answer> GetByIdAsync(string id)
        {
            return await _context.LoadAsync<Answer>(id);
        }
    }
}
