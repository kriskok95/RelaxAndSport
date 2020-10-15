namespace RelaxAndSport.Infrastructure.Booking.Configuration.TrainingsSchedule
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;

    public class TrainingAppointmentConfiguration : IEntityTypeConfiguration<TrainingAppointment>
    {
        public void Configure(EntityTypeBuilder<TrainingAppointment> builder)
        {
            builder
                .HasKey(ta => ta.Id);

            builder
                .OwnsOne(ta => ta.TimeRange, o =>
                {
                    o.WithOwner();

                    o.Property(tr => tr.Start);
                    o.Property(tr => tr.End);
                });
        }
    }
}
