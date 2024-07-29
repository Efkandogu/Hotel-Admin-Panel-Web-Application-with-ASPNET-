using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class Authority
    {
        [Key]
        public int ID { get; set; }
        public string NameandSurname{ get; set; }
        public string AuthorityLevel { get; set; }
        public DateTime AuthorityStart { get; set; }
        public DateTime AuthorityEnd { get; set; }
        public string AuthorityStatus { get; set; }
        public DateTime EndEntry { get; set; }
        public bool IsDeleted { get; set; }

        List<Record> Record { get; set; }
    }
}