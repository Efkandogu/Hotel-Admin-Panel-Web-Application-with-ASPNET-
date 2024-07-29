using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class Guest
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long TcNo { get; set; }
        public string Nationality { get; set; }
        public string HomeTown { get; set; }

    }
}
