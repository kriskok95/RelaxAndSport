﻿namespace RelaxAndSport.Application.Booking.TrainingsSchedule
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITrainingsScheduleRepository : IRepository<TrainingsSchedule>
    {
        Task<TrainingsSchedule> GetTrainingsSchedule(CancellationToken cancellationToken = default);
    }
}
