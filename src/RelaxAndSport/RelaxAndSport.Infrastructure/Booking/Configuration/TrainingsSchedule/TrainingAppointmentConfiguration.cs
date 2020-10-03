namespace RelaxAndSport.Infrastructure.Booking.Configuration.TrainingsSchedule
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;

    public class TrainingAppointmentConfiguration : IEntityTypeConfiguration<TrainingAppointment>
    {
        public void Configure(EntityTypeBuilder<TrainingAppointment> builder)
        {
            builder
                .HasKey(ta => ta.Id);

            builder
                .Property(ta => ta.Date)
                .IsRequired();
        }
    }
}
