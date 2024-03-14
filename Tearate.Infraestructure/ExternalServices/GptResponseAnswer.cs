using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tearate.Infraestructure.ExternalServices
{
    public class GptResponseAnswer
    {
        public float score { get; set; }
        public string feedback { get; set; }
        public bool generated_by_gpt { get; set; }
        public string reason { get; set; }
    }
}
