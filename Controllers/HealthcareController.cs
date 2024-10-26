using Microsoft.AspNetCore.Mvc;

namespace BookingDoctor.Controllers
{
    public class HealthcareController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult WhoWeAre()
        {
            return View();
        }

        public ActionResult WhatWeDo()
        {
            return View();
        }

        public ActionResult Society()
        {
            return View();
        }

        public ActionResult Investors()
        {
            return View();
        }

        public ActionResult Brand()
        {
            return View();
        }
    }
}
