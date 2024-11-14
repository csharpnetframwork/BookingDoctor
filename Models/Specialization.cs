namespace BookingDoctor.Models
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Doctor> Doctors { get; set; }
    }
}
