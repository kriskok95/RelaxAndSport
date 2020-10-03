﻿
namespace RelaxAndSport.Infrastructure.TrainingsBooking.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.TrainingsBooking;
    using RelaxAndSport.Domain.TrainingsBooking.Models.Trainings;
    using RelaxAndSport.Infrastructure.Common.Persistance;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrainingsRepository : DataRepository<ITrainingsBookingDbContext, Training>, ITrainingsRepository
    {
        public TrainingsRepository(ITrainingsBookingDbContext db) 
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
