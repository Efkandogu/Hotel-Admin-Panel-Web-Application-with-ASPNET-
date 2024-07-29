using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class RoomFeature
    {
        [Key]
        public int ID { get; set; }
        public bool TV { get; set; }
        public bool AirConditioning { get; set; }
        public bool Cupboard { get; set; }
        public bool Hanger { get; set; }
        public bool Freezer { get; set; }
        public int RoomID { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

    }
}