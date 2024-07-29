using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class ErrorLog
    {
        [Key]
        public int ID { get; set; }
        public string ExMessage { get; set; }
        public string ExSource { get; set; }
        public string ExStackTrace { get; set; }
        public string Exception { get; set; }
        public string RegistryUsername { get; set; }
        public DateTime History { get; set; }
    }
}