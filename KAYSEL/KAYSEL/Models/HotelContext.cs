using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class HotelContext:DbContext
    {

        public HotelContext():base("HoteldB") 
        {
            Database.SetInitializer(new HotelInitializer());

        }
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RevenueInformation> RevenueInformations { get; set;}
        
    }
}