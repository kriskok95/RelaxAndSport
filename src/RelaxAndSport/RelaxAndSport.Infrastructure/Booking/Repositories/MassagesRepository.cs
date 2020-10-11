namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.Massages;
    using RelaxAndSport.Application.Booking.Massages.Queries.Common;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MassagesRepository : DataRepository<IBookingDbContext, Massage>, IMassagesRepository
    {
        private readonly IMapper mapper;

        public MassagesRepository(
            IBookingDbContext db,
            IMapper mapper)
            : base(db)
            => this.mapper = mapper;

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

        public async Task<MassageOutputModel> GetDetails(int id, CancellationToken cancellationToken)
        {
            var massage = await this.Data.Massages.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            return this.mapper
                .Map<MassageOutputModel>(massage);
        }

        public async Task<IEnumerable<MassageOutputModel>> GetAllMassagesDetails(CancellationToken cancellationToken)
        {
            var allMassages = await this.Data
                .Massages
                .ToListAsync();

            return this.mapper
                .Map<IEnumerable<MassageOutputModel>>(allMassages);
        }
    }
}
