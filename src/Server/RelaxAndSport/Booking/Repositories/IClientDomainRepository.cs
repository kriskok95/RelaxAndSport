namespace RelaxAndSport.Domain.Booking.Repositories
{
    using RelaxAndSport.Domain.Booking.Models.Client;
    using RelaxAndSport.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IClientDomainRepository : IDomainRepository<Client>
    {
        Task<Client> FindByUser(string userId, CancellationToken cancellationToken);
    }
}
