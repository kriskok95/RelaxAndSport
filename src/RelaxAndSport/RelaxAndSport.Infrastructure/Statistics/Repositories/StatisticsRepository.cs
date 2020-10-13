namespace RelaxAndSport.Infrastructure.Statistics.Repositories
{
    using RelaxAndSport.Application.Statistics;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using RelaxAndSport.Domain.Statistics.Models;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsRepository
    {
        public StatisticsRepository(IStatisticsDbContext db) 
            : base(db)
        {
        }

        public async Task IncrementMassagesAppointments(CancellationToken cancellationToken)
        {
            var statistics = this
                .Data
                .Statistics
                .SingleOrDefault();

            statistics.AddeMassageAppointment();

            await this.Save(statistics, cancellationToken);
        }

        public Task IncrementTrainingsAppointments(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
