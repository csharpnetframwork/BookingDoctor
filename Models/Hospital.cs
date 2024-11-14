namespace BookingDoctor.Models
{
    public class Hospital
    {
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactNumber { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Doctor> Doctors { get; set; }
    }
}
