using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tearate.Application.DTOs
{
    public class QuestionDto
    {
        public string ExerciseID { get; set; }

        public string QuestionText { get; set; }

        public float Points { get; set; }
    }
}
