namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.Massages;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MassagesRepository : DataRepository<IBookingDbContext, Massage>, IMassagesRepository
    {
        public MassagesRepository(IBookingDbContext db)
            : base(db)
        {

        }

        public async Task<Massage> Find(int id, CancellationToken cancellationToken = default)
            => await this
            .All()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);


        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var massage = await this.Data
                .Massages
                .FindAsync(id);

            if(massage == null)
            {
                return false;
            }

            this.Data
                .Massages
                .Remove(massage);

            await this.Data
                .SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
