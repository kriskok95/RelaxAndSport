namespace RelaxAndSport.Domain.Booking.Repositories
{
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMassagesDomainRepository : IDomainRepository<Massage>
    {
        Task<Massage> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> HasMassage(int id, CancellationToken cancellationToken);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task ValidateMassageExistence(Massage massage, CancellationToken cancellationToken);
    }
}
