namespace RelaxAndSport.Infrastructure.Statistics.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Statistics;
    using RelaxAndSport.Application.Statistics.Commands.Get;
    using RelaxAndSport.Domain.Statistics.Models;
    using RelaxAndSport.Domain.Statistics.Repositories;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>,
        IStatisticsDomainRepository,
        IStatisticsQueryRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(
            IStatisticsDbContext db,
            IMapper mapper) 
            : base(db)
            => this.mapper = mapper;

        public async Task IncrementMassagesAppointments(CancellationToken cancellationToken)
        {
            var statistics = await this.GetStatistics(cancellationToken);
            statistics.AddeMassageAppointment();

            await this.Save(statistics, cancellationToken);
        }

        public async Task IncrementTrainingsAppointments(CancellationToken cancellationToken)
        {
            var statistics = await this.GetStatistics(cancellationToken);
            statistics.AddteTrainingAppointment();

            await this.Save(statistics, cancellationToken);
        }

        public async Task DecrementMassageAppointments(CancellationToken cancellationToken = default)
        {
            var statistics = await this.GetStatistics(cancellationToken);
            statistics.RemovedMassageAppointment();

            await this.Save(statistics, cancellationToken);
        }

        public async Task DecrementTrainingAppointments(CancellationToken cancellationToken = default)
        {
            var statistics = await this.GetStatistics(cancellationToken);
            statistics.RemovedTrainingAppointment();

            await this.Save(statistics, cancellationToken);
        }

        public async Task<GetStatisticsOutputModel> GetStatisticsOutputModel(CancellationToken cancellationToken = default)
        {
            var statistics = await this
                .Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            return this.mapper
                .Map<GetStatisticsOutputModel>(statistics);
        }

        private async Task<Statistics> GetStatistics(CancellationToken cancellationToken = default)
            => await this
            .Data
            .Statistics
            .SingleOrDefaultAsync(cancellationToken);
    }
}
