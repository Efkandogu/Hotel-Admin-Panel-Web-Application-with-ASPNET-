using KAYSEL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KAYSEL.Controllers
{
    public class RevenueController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            try
            {
                var today = DateTime.Today;

                var dailyRevenue = db.Records
                    .Where(r => DbFunctions.TruncateTime(r.DateOfRegistration) == today)
                    .Sum(r => (decimal?)r.Revenues) ?? 0;

                var monthlyRevenue = db.Records
                    .Where(r => r.DateOfRegistration.Year == today.Year && r.DateOfRegistration.Month == today.Month)
                    .Sum(r => (decimal?)r.Revenues) ?? 0;

                var yearlyRevenue = db.Records
                    .Where(r => r.DateOfRegistration.Year == today.Year)
                    .Sum(r => (decimal?)r.Revenues) ?? 0;

                var info = new RevenueInformation
                {
                    DailyRevenue = dailyRevenue,
                    MonthlyRevenue = monthlyRevenue,
                    YearlyRevenue = yearlyRevenue
                };
                db.SaveChanges();

                return View(info);
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
        }
    }
}
         
