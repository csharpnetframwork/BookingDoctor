namespace BookingDoctor.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public int HospitalId { get; set; }
        public string PhotoUrl { get; set; }
        public int SpecializationId { get; set; }
        // Navigation property
        public Hospital Hospital { get; set; }
    }
}
