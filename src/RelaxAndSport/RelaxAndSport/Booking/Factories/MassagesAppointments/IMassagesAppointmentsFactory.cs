namespace RelaxAndSport.Domain.Booking.Factories.MassagesAppointments
{
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;
    using System;

    public interface IMassagesAppointmentsFactory : IFactory<MassageAppointment>
    {
        IMassagesAppointmentsFactory WithMassage(Massage massage);

        IMassagesAppointmentsFactory WithTimeRange(DateTime startDate, int duration);

        IMassagesAppointmentsFactory WithTimeRange(DateTimeRange timeRange);
    }
}
