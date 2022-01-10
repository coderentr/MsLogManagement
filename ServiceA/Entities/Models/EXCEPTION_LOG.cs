using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceA.Entities.Models
{
    public class EXCEPTION_LOG
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        [MaxLength(50)]
        public string ServiceName { get; set; }
        [MaxLength(50)]
        public string ActionName { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
       
    }
}
