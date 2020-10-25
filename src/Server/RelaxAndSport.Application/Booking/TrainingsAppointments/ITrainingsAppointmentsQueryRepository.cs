namespace RelaxAndSport.Application.Booking.TrainingsAppointments
{
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainingsAppointmentsQueryRepository : IQueryRepository<TrainingAppointment>
    {
        Task<IEnumerable<TrainingAppointmentOutputModel>> GetByDate(DateTime date);
    }
}
