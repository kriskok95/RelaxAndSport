namespace RelaxAndSport.Infrastructure.Booking.Configuration.TrainingsSchedule
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;

    public class TrainingsScheduleConfiguration : IEntityTypeConfiguration<TrainingsSchedule>
    {
        public void Configure(EntityTypeBuilder<TrainingsSchedule> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(t => t.TrainingAppointments)
                .WithOne()
                .HasForeignKey("AppointmentId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
