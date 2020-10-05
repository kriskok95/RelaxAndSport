namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using RelaxAndSport.Application.Booking.Client;
    using RelaxAndSport.Domain.Booking.Models.Client;
    using RelaxAndSport.Infrastructure.Common.Persistence;

    internal class ClientRepository : DataRepository<IBookingDbContext, Client>, IClientRepository
    {
        public ClientRepository(IBookingDbContext db) 
            : base(db)
        {
        }


    }
}
