using Microsoft.AspNetCore.Mvc;

namespace BookingDoctor.Controllers
{
    public class DoctorController : Controller
    {
        
        public ActionResult GeneralPractice()
        {
            return View();
        }

        public ActionResult Gynecology()
        {
            return View();
        }

        public ActionResult Diabetology()
        {
            return View();
        }
        public ActionResult BookAppointment()
        {
            return View();
        }
    }
}
