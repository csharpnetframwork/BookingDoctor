using Microsoft.EntityFrameworkCore;

namespace BookingDoctor.Models
{
    public class HealthcareContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public HealthcareContext(DbContextOptions<HealthcareContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and keys if necessary
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Hospital)
                .WithMany(h => h.Doctors)
                .HasForeignKey(d => d.HospitalId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Hospital)
                .WithMany()
                .HasForeignKey(a => a.HospitalId);

            // Add more configurations if needed
        }
    }
}
