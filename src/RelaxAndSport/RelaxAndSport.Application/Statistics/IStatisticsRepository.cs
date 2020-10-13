namespace RelaxAndSport.Application.Statistics
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Statistics.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticsRepository : IRepository<Statistics>
    {
        Task IncrementMassagesAppointments(CancellationToken cancellationToken = default);

        Task IncrementTrainingsAppointments(CancellationToken cancellationToken = default);
    }
}
