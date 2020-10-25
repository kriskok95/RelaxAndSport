namespace RelaxAndSport.Application.Booking.MassagesAppointments
{
    using RelaxAndSport.Application.Booking.MassagesAppointments.Queries.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMassagesAppointmentsQueryRepository : IQueryRepository<MassageAppointment>
    {
        Task<IEnumerable<MassageAppointmentOutputModel>> GetByDate(DateTime date);
    }
}
