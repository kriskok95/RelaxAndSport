namespace RelaxAndSport.Application.Booking.Massages
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMassagesRepository : IRepository<Massage>
    {
        Task<Massage> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Type> GetType(int id, CancellationToken cancellationToken = default);
    }
}
