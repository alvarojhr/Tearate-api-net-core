using Amazon.DynamoDBv2.DataModel;

namespace Tearate.Domain.Entities
{
    [DynamoDBTable("Questions")]
    public class Question
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("question_id")]
        public string QuestionID { get; set; }

        [DynamoDBProperty("exercise_id")]
        public string ExerciseID { get; set; }

        [DynamoDBProperty("question_text")]
        public string QuestionText { get; set; }

        [DynamoDBProperty("points")]
        public float Points { get; set; }
    }
}
