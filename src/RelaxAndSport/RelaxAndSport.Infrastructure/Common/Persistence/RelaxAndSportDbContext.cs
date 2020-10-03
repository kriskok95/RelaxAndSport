namespace RelaxAndSport.Infrastructure.Common.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;
    using RelaxAndSport.Infrastructure.Booking;
    using RelaxAndSport.Infrastructure.Identity;
    using System.Reflection;

    internal class RelaxAndSportDbContext : IdentityDbContext<User>,
        IBookingDbContext
    {
        public RelaxAndSportDbContext(
            DbContextOptions<RelaxAndSportDbContext> options)
            : base(options)
        {

        }

        public DbSet<Massage> Massages { get; set; } = default!;

        public DbSet<MassageAppointment> MassageAppointments { get; set; } = default!;

        public DbSet<MassagesSchedule> MassagesSchedules { get; set; } = default!;

        public DbSet<Training> Trainings { get; set; } = default!;

        public DbSet<Trainer> Trainers { get; set; } = default!;

        public DbSet<TrainingAppointment> TrainingAppointments { get; set; } = default!;

        public DbSet<TrainingsSchedule> TrainingsSchedules { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
