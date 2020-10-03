namespace RelaxAndSport.Infrastructure.TrainingsBooking
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Domain.TrainingsBooking.Models.Trainings;
    using RelaxAndSport.Domain.TrainingsBooking.Models.TrainingSchedule;
    using RelaxAndSport.Infrastructure.Common.Persistance;

    public interface ITrainingsBookingDbContext : IDbContext
    {
        DbSet<Training> Trainings { get; }

        DbSet<Trainer> Trainers { get; }

        DbSet<TrainingAppointment> TrainingAppointments { get; }

        DbSet<TrainingSchedule> TrainingSchedules { get; }
    }
}
