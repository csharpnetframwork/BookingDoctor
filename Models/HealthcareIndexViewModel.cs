namespace BookingDoctor.Models
{
    public class HealthcareIndexViewModel
    {
        public List<Hospital> Hospitals { get; set; } = new List<Hospital>();
        public List<Doctor> FeaturedDoctors { get; set; } = new List<Doctor>();
    }
}
