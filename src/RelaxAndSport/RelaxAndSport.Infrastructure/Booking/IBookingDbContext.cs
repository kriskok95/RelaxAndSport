using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;

namespace RelaxAndSport.Infrastructure.Booking
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Booking.Models.TrainingSchedule;
    using RelaxAndSport.Infrastructure.Common.Persistance;

    public interface IBookingDbContext : IDbContext
    {
        DbSet<Massage> Massages { get; }

        DbSet<Type> Types { get; }

        DbSet<MassageAppointment> MassageAppointments { get; }

        DbSet<MassagesSchedule> MassagesSchedules { get; }

        DbSet<Training> Trainings { get; }

        DbSet<Trainer> Trainers { get; }

        DbSet<TrainingAppointment> TrainingAppointments { get; }

        DbSet<TrainingsSchedule> TrainingsSchedules { get; }
    }
}
