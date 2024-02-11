using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight_Watchers.core.Response
{
    public class BaseResponse
    {
        public bool Succed { get; set; }

        public string message { get; set; }
        
        public BaseResponse()
        {
        }
    }
}
