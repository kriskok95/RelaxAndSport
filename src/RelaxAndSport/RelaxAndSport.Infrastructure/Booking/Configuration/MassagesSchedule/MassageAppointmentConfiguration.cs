namespace RelaxAndSport.Infrastructure.Booking.Configuration.MassagesSchedule
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;

    public class MassageAppointmentConfiguration : IEntityTypeConfiguration<MassageAppointment>
    {
        public void Configure(EntityTypeBuilder<MassageAppointment> builder)
        {
            builder
                .HasKey(ma => ma.Id);

            builder
                .Property(ma => ma.StartDate)
                .IsRequired();
        }
    }
}
