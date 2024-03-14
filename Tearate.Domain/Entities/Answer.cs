using Amazon.DynamoDBv2.DataModel;

namespace Tearate.Domain.Entities
{
    [DynamoDBTable("Answers")]
    public class Answer
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("answer_id")]
        public string AnswerID { get; set; }

        [DynamoDBProperty("question_id")]
        public string QuestionID { get; set; }

        [DynamoDBProperty("student_id")]
        public string StudentID { get; set; }

        [DynamoDBProperty("response")]
        public string Response { get; set; }

        [DynamoDBProperty("rate")]
        public float Rate { get; set; }

        [DynamoDBProperty("feedback")]
        public string Feedback { get; set; }
    }
}
