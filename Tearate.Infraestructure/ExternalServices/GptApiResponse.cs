using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tearate.Infraestructure.ExternalServices
{
    public class GptApiResponse
    {
        public IEnumerable<GptChoice> choices { get; set; }
    }
}
