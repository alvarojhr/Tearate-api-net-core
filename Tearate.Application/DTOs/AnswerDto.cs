using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tearate.Application.DTOs
{
    public class AnswerDto
    {
        public string QuestionID { get; set; }

        public string StudentID { get; set; }

        public string Response { get; set; }

        public float Rate { get; set; }

        public string Feedback { get; set; }
    }
}
