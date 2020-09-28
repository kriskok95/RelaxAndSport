namespace RelaxAndSport.Infrastructure.MassagesBooking
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Domain.MassagesBooking.Models.Massages;
    using RelaxAndSport.Domain.MassagesBooking.Models.MassagesSchedule;
    using RelaxAndSport.Infrastructure.Common.Persistance;

    public interface IMassagesBookingDbContext : IDbContext
    {
        DbSet<Massage> Massages { get; }

        DbSet<Type> Types { get; }

        DbSet<MassageAppointment> MassageAppointments { get; }

        DbSet<MassagesSchedule> MassagesSchedules { get; }
    }
}
