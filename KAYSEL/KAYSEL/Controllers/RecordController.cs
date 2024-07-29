using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KAYSEL.Models;

namespace KAYSEL.Controllers
{
    public class RecordController : Controller
    {
        private HotelContext db = new HotelContext();

        
        public ActionResult Index()
        {
            var records = db.Records.Include(r => r.Authority).Include(r => r.Guest).Include(r=>r.Room);
            return View(records.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.AuthorityId = new SelectList(db.Authorities, "ID", "NameandSurname");
            var availableRooms = db.Rooms.Where(r => r.RoomOccupancy == true).ToList();
            ViewBag.RoomId = new SelectList(availableRooms, "ID", "RoomNo");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorityId,Revenues,RoomId,,ExMessage,ExSource,ExStackTrace,Exception,RegistryUsername,History")] Record record, string GuestFirstName, string GuestLastName, long GuestTcNo, string GuestNationality, string GuestHomeTown)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var guest = new Guest
                    {
                        FirstName = GuestFirstName,
                        LastName = GuestLastName,
                        TcNo = GuestTcNo,
                        Nationality = GuestNationality,
                        HomeTown = GuestHomeTown
                    };

                    db.Guests.Add(guest);
                    db.SaveChanges();

                    record.DateOfRegistration = DateTime.Now;
                    record.GuestID = guest.ID;

                    db.Records.Add(record);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                string hata = ex.Message;

 
                var errorLog = new ErrorLog
                {
                    ExMessage = ex.Message,
                    ExSource = ex.Source,
                    ExStackTrace = ex.StackTrace,
                    Exception = ex.ToString(),
                    RegistryUsername = User.Identity.Name,
                    History = DateTime.Now
                };
                db.ErrorLogs.Add(errorLog);
                db.SaveChanges();

                
                return Json(new { result = 0, message = hata });
            }

            ViewBag.AuthorityId = new SelectList(db.Authorities, "ID", "NameandSurname", record.AuthorityID);
            var availableRooms = db.Rooms.Where(r => r.RoomOccupancy == true).ToList();
            ViewBag.RoomId = new SelectList(availableRooms, "ID", "RoomNo", record.RoomID);

            return View(record);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorityId = new SelectList(db.Authorities, "ID", "NameandSurname", record.AuthorityID);
            ViewBag.GuestId = new SelectList(db.Guests, "ID", "FirstName", record.GuestID);
            var availableRooms = db.Rooms.Where(r => r.RoomOccupancy == true).ToList();
            ViewBag.RoomId = new SelectList(availableRooms, "ID", "RoomNo");
            return View(record);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Revenues,AuthorityId,DateOfRegistration,IsDeleted,GuestId,RoomId,ExMessage,ExSource,ExStackTrace,Exception,RegistryUsername,History")] Record record)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(record).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex) 
            {
                string hata = ex.Message;


                var errorLog = new ErrorLog
                {
                    ExMessage = ex.Message,
                    ExSource = ex.Source,
                    ExStackTrace = ex.StackTrace,
                    Exception = ex.ToString(),
                    RegistryUsername = User.Identity.Name,
                    History = DateTime.Now
                };
                db.ErrorLogs.Add(errorLog);
                db.SaveChanges();
            }
            ViewBag.AuthorityId = new SelectList(db.Authorities, "ID", "NameandSurname", record.AuthorityID);
            ViewBag.GuestId = new SelectList(db.Guests, "ID", "FirstName", record.GuestID);
            var availableRooms = db.Rooms.Where(r => r.RoomOccupancy == true).ToList();
            ViewBag.RoomId = new SelectList(availableRooms, "ID", "RoomNo", record.RoomID);
            return View(record);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Record record = db.Records
            .Include(r => r.Guest)
            .Include(r => r.Room)
            .Include(r => r.Authority)
            .FirstOrDefault(r => r.ID == id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);

        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "ID,Revenues,AuthorityId,DateOfRegistration,IsDeleted,GuestId,RoomId,ExMessage,ExSource,ExStackTrace,Exception,RegistryUsername,History")]Record records ,int id)
        {
            try
            {
                 Record record = db.Records
                .Include(r => r.Guest)
                .Include(r => r.Room)
                .Include(r => r.Authority)
                .FirstOrDefault(r => r.ID == id);
                db.Records.Find(id);
                db.Records.Remove(record);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                var errorLog = new ErrorLog
                {
                    ExMessage = ex.Message,
                    ExSource = ex.Source,
                    ExStackTrace = ex.StackTrace,
                    Exception = ex.ToString(),
                    RegistryUsername = User.Identity.Name,
                    History = DateTime.Now

                };
                db.ErrorLogs.Add(errorLog);
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
