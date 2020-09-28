﻿namespace RelaxAndSport.Infrastructure.MassagesBooking.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.MassagesBooking.Massages;
    using RelaxAndSport.Domain.MassagesBooking.Models.Massages;
    using RelaxAndSport.Infrastructure.Common.Persistance;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MassagesRepository : DataRepository<IMassagesBookingDbContext, Massage>, IMassagesRepository
    {
        public MassagesRepository(IMassagesBookingDbContext db)
            : base(db)
        {

        }

        public async Task<Massage> Find(int id, CancellationToken cancellationToken = default)
            => await this
            .All()
            .Include(x => x.Type)
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

        public async Task<Type> GetType(int id, CancellationToken cancellationToken = default)
            => await this.Data
            .Types
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
