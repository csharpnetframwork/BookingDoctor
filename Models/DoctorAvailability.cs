namespace BookingDoctor.Models
{
    public class DoctorAvailability
    {
        public int DoctorAvailabilityId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }

        // Navigation property
        public Doctor Doctor { get; set; }
    }
}
