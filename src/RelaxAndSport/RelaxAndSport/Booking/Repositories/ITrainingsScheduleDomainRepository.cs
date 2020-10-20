namespace RelaxAndSport.Domain.Booking.Repositories
{
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;
    using RelaxAndSport.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITrainingsScheduleDomainRepository : IDomainRepository<TrainingsSchedule>
    {
        Task<TrainingsSchedule> GetTrainingsSchedule(CancellationToken cancellationToken = default);
    }
}
