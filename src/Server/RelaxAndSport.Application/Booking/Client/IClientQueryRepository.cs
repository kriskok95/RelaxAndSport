namespace RelaxAndSport.Application.Booking.Client
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.Client;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IClientQueryRepository : IQueryRepository<Client>
    {
        
    }
}
