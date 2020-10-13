namespace RelaxAndSport.Infrastructure.Statistics.Repositories
{
    using RelaxAndSport.Application.Statistics;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using RelaxAndSport.Domain.Statistics.Models;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;
    using RelaxAndSport.Application.Statistics.Commands.Get;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(
            IStatisticsDbContext db,
            IMapper mapper) 
            : base(db)
            => this.mapper = mapper;

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

        public async Task<GetStatisticsOutputModel> GetStatistics(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data.Statistics.SingleOrDefaultAsync();

            return this.mapper
                .Map<GetStatisticsOutputModel>(statistics);
        }
    }
}
