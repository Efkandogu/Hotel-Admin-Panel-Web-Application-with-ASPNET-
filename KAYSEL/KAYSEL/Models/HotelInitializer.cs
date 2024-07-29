using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KAYSEL.Models
{
    public class HotelInitializer:DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            List<Room> rooms = new List<Room>() 
            {
                new Room() {RoomNo=101,RoomOccupancy=false,RoomPrice=1250,Resim="1.jpeg",IsDeleted=false},
                new Room() {RoomNo=102,RoomOccupancy=true,RoomPrice=1250,Resim="1.jpeg",IsDeleted=false},
                new Room() {RoomNo=103,RoomOccupancy=true,RoomPrice=1250,Resim="1.jpeg",IsDeleted=false},
                new Room() {RoomNo=104,RoomOccupancy=true,RoomPrice=1450,Resim="1.jpeg",IsDeleted=false},
                new Room() {RoomNo=105,RoomOccupancy=false,RoomPrice=1450,Resim="2.jpeg",IsDeleted=false},
                new Room() {RoomNo=106,RoomOccupancy=true,RoomPrice=1450,Resim="2.jpeg",IsDeleted=false},
                new Room() {RoomNo=107,RoomOccupancy=true,RoomPrice=1450,Resim="2.jpeg",IsDeleted=false},
                new Room() {RoomNo=108,RoomOccupancy=true,RoomPrice=1650,Resim="2.jpeg",IsDeleted=false},
                new Room() {RoomNo=109,RoomOccupancy=true,RoomPrice=1650,Resim="3.jpeg",IsDeleted=false},
                new Room() {RoomNo=110,RoomOccupancy=true,RoomPrice=1650,Resim="3.jpeg",IsDeleted=false},
                new Room() {RoomNo=111,RoomOccupancy=true,RoomPrice=1650,Resim="3.jpeg",IsDeleted=false},
                new Room() {RoomNo=112,RoomOccupancy=true,RoomPrice=1650,Resim="3.jpeg",IsDeleted=false},
                new Room() {RoomNo=113,RoomOccupancy=true,RoomPrice=1850,Resim="4.jpeg",IsDeleted=false},
                new Room() {RoomNo=114,RoomOccupancy=true,RoomPrice=1850,Resim="4.jpeg",IsDeleted=false},
                new Room() {RoomNo=115,RoomOccupancy=false,RoomPrice=1850,Resim="4.jpeg",IsDeleted=false},
                new Room() {RoomNo=116,RoomOccupancy=true,RoomPrice=1850,Resim="4.jpeg",IsDeleted=false},
                
            };

            foreach(var item in rooms) 
            {
                context.Rooms.Add(item);
            }

            context.SaveChanges();


            List<RoomFeature> roomFeatures = new List<RoomFeature>() 
            {
                new RoomFeature() {TV=true,AirConditioning=false,Cupboard=false,Hanger = true,Freezer = false,RoomID=1},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=false,Hanger = true,Freezer = false,RoomID=2},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=false,Hanger = true,Freezer = false,RoomID=3},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=false,Hanger = true,Freezer = false,RoomID=4},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = false,RoomID=5},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = false,RoomID=6},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = false,RoomID=7},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = false,RoomID=8},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = true,RoomID=9},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = true,RoomID=10},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = true,RoomID=11},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = false,Freezer = true,RoomID=12},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = true,Freezer = true,RoomID=13},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = true,Freezer = true,RoomID=14},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = true,Freezer = true,RoomID=15},
                new RoomFeature() {TV=true,AirConditioning=true,Cupboard=true,Hanger = true,Freezer = true,RoomID=16},
            };

            foreach (var item in roomFeatures)
            {
                context.RoomFeatures.Add(item);
            }


            context.SaveChanges();

            List<Authority> authorities = new List<Authority>()
            {
                 new Authority
                         {
        
                      NameandSurname = "Person 5",
                      AuthorityLevel = "Receptionist",
                      AuthorityStart = DateTime.Now.AddMonths(-1),
                      AuthorityEnd = DateTime.Now.AddMonths(12), 
                      AuthorityStatus = "Active",
                      EndEntry = DateTime.Now,
                      IsDeleted = false
                           },
                new Authority
                {

                    NameandSurname = "Person 4",
                    AuthorityLevel = "Receptionist",
                    AuthorityStart = DateTime.Now.AddMonths(-1),
                    AuthorityEnd = DateTime.Now.AddMonths(12),
                    AuthorityStatus = "Active",
                    EndEntry = DateTime.Now,
                    IsDeleted = false
                },
                new Authority
                {

                    NameandSurname = "Person3",
                    AuthorityLevel = "Security",
                    AuthorityStart = DateTime.Now.AddMonths(-1),
                    AuthorityEnd = DateTime.Now.AddMonths(12),
                    AuthorityStatus = "Active",
                    EndEntry = DateTime.Now,
                    IsDeleted = false
                },
                new Authority
                {

                    NameandSurname = "Person2",
                    AuthorityLevel = "Housekeeper",
                    AuthorityStart = DateTime.Now.AddMonths(-3),
                    AuthorityEnd = DateTime.Now.AddMonths(12),
                    AuthorityStatus = "Active",
                    EndEntry = DateTime.Now,
                    IsDeleted = false
                },
                new Authority
                {

                    NameandSurname = "Person1",
                    AuthorityLevel = "Housekeeper",
                    AuthorityStart = DateTime.Now.AddMonths(-2),
                    AuthorityEnd = DateTime.Now.AddMonths(12),
                    AuthorityStatus = "Active",
                    EndEntry = DateTime.Now,
                    IsDeleted = false
                }
            };

            foreach (var item in authorities)
            {
                context.Authorities.Add(item);
            }

            context.SaveChanges();

            List<Guest> guests = new List<Guest>() 
            {
            
                new Guest{FirstName="Guest1",LastName="Guest1",TcNo=11111111111,Nationality="Turkey",HomeTown="Ankara"},
                new Guest{FirstName="Guest2",LastName="Guest2",TcNo=11111111111,Nationality="England",HomeTown="London"},
                new Guest{FirstName="Guest3",LastName="Guest3",TcNo=11111111111,Nationality="Turkey",HomeTown="Sivas"},
               
            };

            foreach (var item in guests)
            {
                context.Guests.Add(item);
            }

            context.SaveChanges();

            List<Record> records = new List<Record>() 
            {
                new Record{ RoomID = 1,GuestID=1,Revenues=1250,AuthorityID=2,DateOfRegistration=DateTime.Now.AddMonths(-1),IsDeleted=true},
                new Record{ RoomID = 5,GuestID=2,Revenues=1450,AuthorityID=1,DateOfRegistration=DateTime.Now.AddMonths(-2),IsDeleted=true},
                new Record{ RoomID=15,GuestID=3,Revenues=1850,AuthorityID=1,DateOfRegistration=DateTime.Now.AddMonths(-1),IsDeleted=true}
            };
            foreach (var item in records)
            {
                context.Records.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}