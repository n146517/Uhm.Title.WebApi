using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhm.Title.Data.Models
{
    public class ErrorLogging
    {
        [Key]
        public int ErrorLoggingId { get; set; }
        public string InnerException { get; set; } = string.Empty;
        public string ExceptionMsg { get; set; } = string.Empty;
        public string ExceptionType { get; set; } = string.Empty;
        public string ExceptionSource { get; set; } = string.Empty;
        public string ExceptionURL { get; set; } = string.Empty;
        public DateTime LoggingDate { get; set; } = DateTime.UtcNow;
    }
}
