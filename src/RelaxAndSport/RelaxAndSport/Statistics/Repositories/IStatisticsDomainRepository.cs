namespace RelaxAndSport.Domain.Statistics.Repositories
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Statistics.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticsDomainRepository : IDomainRepository<Statistics>
    {
        Task IncrementMassagesAppointments(CancellationToken cancellationToken = default);

        Task IncrementTrainingsAppointments(CancellationToken cancellationToken = default);
    }
}
