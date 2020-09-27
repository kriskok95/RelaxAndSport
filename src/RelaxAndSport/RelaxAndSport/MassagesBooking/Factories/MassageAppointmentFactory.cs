namespace RelaxAndSport.Domain.MassagesBooking.Factories
{
    using RelaxAndSport.Domain.MassagesBooking.Models.MassagesSchedule;
    using System;

    public class MassageAppointmentFactory : IMassageAppointmentFactory
    {
        private readonly Massage massage = default!;
        private readonly DateTime startDate = default!;
        private readonly DateTime endDate = default!;

    }
}
