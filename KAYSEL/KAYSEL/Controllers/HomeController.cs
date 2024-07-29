using KAYSEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace KAYSEL.Controllers
{
    public class HomeController : Controller
    {
        private HotelContext context = new HotelContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}