using Amazon.DynamoDBv2.DataModel;

namespace Tearate.Domain.Entities
{
    [DynamoDBTable("Students")]
    public class Student
    {
        [DynamoDBHashKey] // Assuming StudentID is your primary key
        [DynamoDBProperty("student_id")]
        public string StudentID { get; set; }

        [DynamoDBProperty("name")]
        public string Name { get; set; }
    }
}
