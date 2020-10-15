namespace RelaxAndSport.Infrastructure.Common.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Domain.Booking.Models.Client;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;
    using RelaxAndSport.Domain.Common.Models;
    using RelaxAndSport.Domain.Statistics.Models;
    using RelaxAndSport.Infrastructure.Booking;
    using RelaxAndSport.Infrastructure.Common.Events;
    using RelaxAndSport.Infrastructure.Identity;
    using RelaxAndSport.Infrastructure.Statistics;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RelaxAndSportDbContext : IdentityDbContext<User>,
        IBookingDbContext,
        IStatisticsDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> savesChangesTracker;

        public RelaxAndSportDbContext(
            DbContextOptions<RelaxAndSportDbContext> options, 
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;
            this.savesChangesTracker = new Stack<object>();
        }

        public DbSet<Client> Clients { get; set; } = default!;

        public DbSet<Massage> Massages { get; set; } = default!;

        public DbSet<MassageAppointment> MassageAppointments { get; set; } = default!;

        public DbSet<MassagesSchedule> MassagesSchedules { get; set; } = default!;

        public DbSet<Training> Trainings { get; set; } = default!;

        public DbSet<Trainer> Trainers { get; set; } = default!;

        public DbSet<TrainingAppointment> TrainingAppointments { get; set; } = default!;

        public DbSet<TrainingsSchedule> TrainingsSchedules { get; set; } = default!;

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
