﻿namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.TrainingsAppointments;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.Common;
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Booking.Repositories;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrainingsAppointmentsRepository : DataRepository<IBookingDbContext, TrainingAppointment>,
        ITrainingsAppointmentsDomainRepository,
        ITrainingsAppointmentsQueryRepository
    {
        private readonly IMapper mapper;

        public TrainingsAppointmentsRepository(
            IBookingDbContext db,
            IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<bool> Delete(TrainingAppointment trainingAppointment, CancellationToken cancellationToken)
        {
            if (trainingAppointment == null)
            {
                return false;
            }

            this.Data
                .TrainingAppointments
                .Remove(trainingAppointment);

            await this.Data
                .SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TrainingAppointmentOutputModel>> GetByDate(DateTime date)
        {
            var trainingsAppointments = await this
                .Data
                .TrainingAppointments
                .Include(ta => ta.Training)
                .Where(ta => ta.TimeRange.End.Date == date.Date)
                .ToListAsync();

            return this.mapper
                .Map<IEnumerable<TrainingAppointmentOutputModel>>(trainingsAppointments);
        }

        public async Task<TrainingAppointment> GetTrainingAppointment(int id, CancellationToken cancellationToken)
        {
            var trainingAppointment = await this.Data
            .TrainingAppointments
            .SingleOrDefaultAsync(ta => ta.Id == id, cancellationToken);

            if(trainingAppointment == null)
            {
                throw new InvalidTrainingAppointmentException($"Training appointment with ID: {id} doesn't exists.");
            }

            return trainingAppointment;
        }
    }
}
