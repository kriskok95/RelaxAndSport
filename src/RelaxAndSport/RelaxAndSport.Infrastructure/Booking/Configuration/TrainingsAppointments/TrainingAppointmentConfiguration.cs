namespace RelaxAndSport.Infrastructure.Booking.Configuration.TrainingsAppointments
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
                .OwnsOne(ta => ta.TimeRange, t =>
                {
                    t.WithOwner();

                    t.Property(tr => tr.Start);
                    t.Property(tr => tr.End);
                });
        }
    }
}
