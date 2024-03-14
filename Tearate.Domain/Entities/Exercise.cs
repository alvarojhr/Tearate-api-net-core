using Amazon.DynamoDBv2.DataModel;

namespace Tearate.Domain.Entities
{
    [DynamoDBTable("Exercises")]
    public class Exercise
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("exercise_id")]
        public string ExerciseID { get; set; }

        [DynamoDBProperty("name")]
        public string Name { get; set; }
    }
}
