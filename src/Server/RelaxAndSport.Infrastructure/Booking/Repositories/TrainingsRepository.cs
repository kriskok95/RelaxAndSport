﻿namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.Trainings;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Booking.Repositories;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrainingsRepository : DataRepository<IBookingDbContext, Training>, 
        ITrainingsDomainRepository,
        ITrainingsQueryRepository
    {
        private readonly IMapper mapper;

        public TrainingsRepository(
            IBookingDbContext db,
            IMapper mapper) 
            : base(db)
        {
            this.mapper = mapper;
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
            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Trainer> GetTrainer(int id, CancellationToken cancellationToken = default)
            => await this.Data
            .Trainers
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        public async Task<IEnumerable<TrainingOutputModel>> GetAll(CancellationToken cancellationToken = default)
        {
            var allTrainings = await this
                .Data
                .Trainings
                .Include(t => t.Trainer)
                .ToListAsync();

            return this.mapper
                .Map<IEnumerable<TrainingOutputModel>>(allTrainings);
        }

        public async Task<TrainingOutputModel> GetTrainingOutputModelById(int id, CancellationToken cancellationToken = default)
        {
            var training = await this
                .Data
                .Trainings
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(t => t.Id == id);

            return this.mapper
                .Map<TrainingOutputModel>(training);
        }

        public async Task<Training> GetById(int id, CancellationToken cancellationToken = default)
            => await this
            .Data
            .Trainings
            .Include(t => t.Trainer)
            .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<Trainer> GetTrainer(string trainerFirstName, string trainerLastName, CancellationToken cancellationToken)
            => await this
            .Data
            .Trainers
            .FirstOrDefaultAsync(t => t.FirstName == trainerFirstName && t.LastName == t.LastName);

        public async Task ValidateTrainingExistence(Training training, CancellationToken cancellationToken)
        {
            var isTrainingExists = await this
                .Data
                .Trainings
                .AnyAsync(t =>
                    t.Category == training.Category &&
                    t.Trainer == training.Trainer &&
                    t.Date == training.Date, cancellationToken);

            if (isTrainingExists)
            {
                throw new InvalidTrainingException("Training with the same category, trainer and date already exists.");
            }
        }
    }
}
