namespace RelaxAndSport.Infrastructure.Booking.Configuration.MassagesAppointments
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;

    public class MassageAppointmentConfiguration : IEntityTypeConfiguration<MassageAppointment>
    {
        public void Configure(EntityTypeBuilder<MassageAppointment> builder)
        {
            builder
                .HasKey(ma => ma.Id);

            builder
                .OwnsOne(ma => ma.TimeRange, t =>
                {
                    t.WithOwner();

                    t.Property(tr => tr.Start);
                    t.Property(tr => tr.End);
                });
        }
    }
}
