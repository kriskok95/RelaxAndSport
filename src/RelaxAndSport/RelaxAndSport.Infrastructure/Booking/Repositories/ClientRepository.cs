namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.Client;
    using RelaxAndSport.Domain.Booking.Models.Client;
    using RelaxAndSport.Domain.Booking.Repositories;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ClientRepository : DataRepository<IBookingDbContext, Client>,
        IClientDomainRepository,
        IClientQueryRepository
    {
        public ClientRepository(IBookingDbContext db) 
            : base(db)
        {
        }

        public async Task<Client> FindByUser(string userId, CancellationToken cancellationToken)
            => await this.Data
            .Clients
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }
}
