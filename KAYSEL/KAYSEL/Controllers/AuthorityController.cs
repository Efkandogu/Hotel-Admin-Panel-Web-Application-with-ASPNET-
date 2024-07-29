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
    public class AuthorityController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Index()

        {

            return View(db.Authorities.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameandSurname,AuthorityLevel,AuthorityStart,AuthorityEnd,AuthorityStatus,IsDeleted,ExMessage,ExSource,ExStackTrace,Exception,RegistryUsername,History")] Authority authority, string nameandsurname, string authoritylevel, DateTime authoritystart, DateTime authorityend, string authoritystatus,bool isdeleted)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var authorities = new Authority
                    {
                        NameandSurname = nameandsurname,
                        AuthorityLevel = authoritylevel,
                        AuthorityStart = authoritystart,
                        AuthorityEnd = authorityend,
                        AuthorityStatus = authoritystatus,
                        IsDeleted = isdeleted


                    };
                    authority.EndEntry = DateTime.Now;
                    db.Authorities.Add(authority);
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

            return View(authority);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authority authority = db.Authorities.Find(id);
            if (authority == null)
            {
                return HttpNotFound();
            }
            return View(authority);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authority authority = db.Authorities.Find(id);
            db.Authorities.Remove(authority);
            db.SaveChanges();
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
