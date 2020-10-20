using Microsoft.EntityFrameworkCore;
using RelaxAndSport.Application.Booking.TrainingsSchedule;
using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;
using RelaxAndSport.Domain.Booking.Repositories;
using RelaxAndSport.Infrastructure.Common.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    internal class TrainingsScheduleRepository : DataRepository<IBookingDbContext, TrainingsSchedule>,
        ITrainingsScheduleDomainRepository,
        ITrainingsScheduleQueryRepository
    {
        public TrainingsScheduleRepository(
            IBookingDbContext db)
            : base(db)
        {
        }

        public async Task<TrainingsSchedule> GetTrainingsSchedule(CancellationToken cancellationToken = default)
            => await this
            .Data
            .TrainingsSchedules
            .SingleOrDefaultAsync();
    }
}
