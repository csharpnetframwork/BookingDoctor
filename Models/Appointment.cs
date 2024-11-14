namespace BookingDoctor.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public int HospitalId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Doctor Doctor { get; set; }
        public Hospital Hospital { get; set; }
    }
}
