namespace RelaxAndSport.Application.Booking.MassagesAppointments
{
    using RelaxAndSport.Application.Booking.MassagesAppointments.Queries.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMassagesAppointmentsRepository : IRepository<MassageAppointment>
    {
        Task<MassageAppointment> GetMassageAppointment(int id);

        Task<bool> Delete(MassageAppointment massageAppointment, CancellationToken cancellationToken);

        Task<IEnumerable<MassageAppointmentOutputModel>> GetByDate(DateTime date);
    }
}
