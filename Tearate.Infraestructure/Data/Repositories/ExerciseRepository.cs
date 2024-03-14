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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DynamoDBContext _context;

        public ExerciseRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task AddAsync(Exercise exercise)
        {
            await _context.SaveAsync(exercise);
        }

        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();

            var allExercises = new List<Exercise>();
            var asyncSearch = _context.ScanAsync<Exercise>(conditions);

            while (!asyncSearch.IsDone)
            {
                var batch = await asyncSearch.GetNextSetAsync();
                allExercises.AddRange(batch);
            }

            return allExercises;
        }

        public async Task<Exercise> GetByIdAsync(string id)
        {
            return await _context.LoadAsync<Exercise>(id);
        }
    }
}
