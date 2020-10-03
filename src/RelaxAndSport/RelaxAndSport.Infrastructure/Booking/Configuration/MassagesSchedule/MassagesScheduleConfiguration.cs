namespace RelaxAndSport.Infrastructure.Booking.Configuration.MassagesSchedule
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;

    public class MassagesScheduleConfiguration : IEntityTypeConfiguration<MassagesSchedule>
    {
        public void Configure(EntityTypeBuilder<MassagesSchedule> builder)
        {
            builder
                .HasKey(mc => mc.Id);

            builder
                .HasMany(mc => mc.MassageAppointments)
                .WithOne()
                .HasForeignKey("MassageAppointmentId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
