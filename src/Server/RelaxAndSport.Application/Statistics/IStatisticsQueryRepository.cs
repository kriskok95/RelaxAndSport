namespace RelaxAndSport.Application.Statistics
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Application.Statistics.Commands.Get;
    using RelaxAndSport.Domain.Statistics.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticsQueryRepository : IQueryRepository<Statistics>
    {
        Task<GetStatisticsOutputModel> GetStatistics(CancellationToken cancellationToken = default);
    }
}
