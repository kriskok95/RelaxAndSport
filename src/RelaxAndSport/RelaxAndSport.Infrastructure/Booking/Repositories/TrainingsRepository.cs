
namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.Trainings;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrainingsRepository : DataRepository<IBookingDbContext, Training>, ITrainingsRepository
    {
        public TrainingsRepository(IBookingDbContext db) 
            : base(db)
        {
        }

        public async Task<Training> Find(int id, CancellationToken cancellationToken = default)
            => await this.All()
            .Include(t => t.Trainer)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var training = await this.Data
                .Trainings
                .FindAsync(id);

            if(training == null)
            {
                return false;
            }

            this.Data.Trainings.Remove(training);

            return true;
        }


        public async Task<Trainer> GetTrainer(int id, CancellationToken cancellationToken = default)
            => await this.Data
            .Trainers
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
