using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Tearate.Domain.Entities;
using Tearate.Domain.Interfaces;

namespace Tearate.Infraestructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DynamoDBContext _context;

        public StudentRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task AddAsync(Student student)
        {
            await _context.SaveAsync(student);
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _context.LoadAsync<Student>(id);
        }

        //TODO: Add lazy loading
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();

            var allStudents = new List<Student>();
            var asyncSearch = _context.ScanAsync<Student>(conditions);

            while (!asyncSearch.IsDone)
            {
                var batch = await asyncSearch.GetNextSetAsync();
                allStudents.AddRange(batch);
            }

            return allStudents;
        }
    }
}
