namespace RelaxAndSport.Application.Booking.Massages
{
    using RelaxAndSport.Application.Booking.Massages.Queries.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMassagesRepository : IRepository<Massage>
    {
        Task<Massage> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> HasMassage(int id, CancellationToken cancellationToken);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<MassageOutputModel> GetDetails(int id, CancellationToken cancellationToken);

        Task<IEnumerable<MassageOutputModel>> GetAllMassagesDetails(CancellationToken cancellationToken);
    }
}
