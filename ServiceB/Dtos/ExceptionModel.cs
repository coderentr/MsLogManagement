using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceB.Dtos
{
    public class ExceptionModel
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ServiceName { get; set; }
        public string ActionName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
