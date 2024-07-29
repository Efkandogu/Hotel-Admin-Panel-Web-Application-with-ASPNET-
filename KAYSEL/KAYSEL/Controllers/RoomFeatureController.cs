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
    public class RoomFeatureController : Controller
    {
        private HotelContext db = new HotelContext();

       
        public ActionResult Index()
        {
            var roomfeature = db.RoomFeatures.Include(r => r.Room);
            return View(roomfeature.ToList());
        }

        

       
        

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomFeature roomFeature = db.RoomFeatures.Find(id);
            if (roomFeature == null)
            {
                return HttpNotFound();
            }
            return View(roomFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TV,AirConditioning,Cupboard,Hanger,Freezer,ExMessage,ExSource,ExStackTrace,Exception,RegistryUsername,History")] RoomFeature roomFeature)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var uploadroom = db.RoomFeatures.Find(roomFeature.ID);
                    if (uploadroom != null)
                    {
                        uploadroom.TV = roomFeature.TV;
                        uploadroom.AirConditioning = roomFeature.AirConditioning;
                        uploadroom.Cupboard = roomFeature.Cupboard;
                        uploadroom.Hanger = roomFeature.Hanger;
                        uploadroom.Freezer = roomFeature.Freezer;

                        db.SaveChanges();
                        TempData["RoomFeature"] = uploadroom;
                        return RedirectToAction("Index");


                    }
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
            return View(roomFeature);
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
