using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        public int RoomNo { get; set; }
        public bool RoomOccupancy { get; set; }
        public decimal RoomPrice { get; set; }
        public string Resim {  get; set; }
        public bool IsDeleted { get; set; }

        List<RoomFeature> Roomfeatures { get; set; }


    }
}