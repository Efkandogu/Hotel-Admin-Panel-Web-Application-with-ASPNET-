using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class RevenueInformation
    {
        [Key]
        public int ID { get; set; } 
        public decimal DailyRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal YearlyRevenue { get; set; }

        public int RecordID { get; set; }

        [ForeignKey("RecordID")]
        public Record Record { get; set; }


    }
}