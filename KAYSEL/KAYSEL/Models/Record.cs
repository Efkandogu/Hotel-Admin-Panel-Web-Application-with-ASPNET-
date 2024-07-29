using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class Record
    {
        [Key]
        public int ID { get; set; }
        public decimal Revenues { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool IsDeleted { get; set; }

        public int AuthorityID { get; set; }

        [ForeignKey("AuthorityID")]
        public Authority Authority { get; set; }

        public int RoomID { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

        public int GuestID { get; set; }

        [ForeignKey("GuestID")]
        public Guest Guest { get; set; }

        public List<RevenueInformation> RevenueInformations { get; set; }
    }
}
