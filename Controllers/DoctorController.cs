using BookingDoctor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingDoctor.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HealthcareContext _context;

        public DoctorController(HealthcareContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GeneralPractice()
        {
            var doctors = await _context.Doctors
                .Include(d => d.Hospital)
                
                .Where(d => d.Specialization.ToLower() == "general practice")
                .ToListAsync();
            return View(doctors);
        }

        public async Task<IActionResult> Gynecology()
        {
            var doctors = await _context.Doctors
                .Include(d => d.Hospital)
               
                .Where(d => d.Specialization.ToLower() == "gynecology")
                .ToListAsync();
            return View(doctors);
        }

        public async Task<IActionResult> Diabetology()
        {
            var doctors = await _context.Doctors
                .Include(d => d.Hospital)
                .Where(d => d.Specialization.ToLower() == "diabetology")
                .ToListAsync();
            return View(doctors);
        }

        public async Task<IActionResult> BookAppointment(int doctorId)
        {
            var doctor = await _context.DoctorAvailability
                .Include(d => d.Doctor)
                .Where(da => da.AvailableDate >= DateTime.Today && da.IsAvailable)
                .FirstOrDefaultAsync(d => d.DoctorId == doctorId);

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                // Verify the selected time slot is still available
                var availability = await _context.DoctorAvailability
                    .FirstOrDefaultAsync(da =>
                        da.DoctorId == appointment.DoctorId &&
                        da.AvailableDate.Date == appointment.AppointmentDate.Date &&
                        da.StartTime <= appointment.TimeSlot &&
                        da.IsAvailable);

                if (availability == null)
                {
                    ModelState.AddModelError("", "Selected time slot is no longer available.");
                    return View(appointment);
                }

                // Mark the time slot as booked
                availability.IsAvailable = false;

                // Add the appointment
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return RedirectToAction("AppointmentConfirmation", new { id = appointment.DoctorId });
            }
            return View(appointment);
        }

        // Optional: Add a method to get available time slots for a specific date
        [HttpGet]
        public async Task<IActionResult> GetAvailableTimeSlots(int doctorId, DateTime date)
        {
            var availableSlots = await _context.DoctorAvailability
                .Where(da =>
                    da.DoctorId == doctorId &&
                    da.AvailableDate.Date == date.Date &&
                    da.IsAvailable)
                .Select(da => new
                {
                    da.DoctorAvailabilityId,
                    da.StartTime,
                    da.EndTime
                })
                .ToListAsync();

            return Json(availableSlots);
        }
    }
}