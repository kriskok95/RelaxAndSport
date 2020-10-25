namespace RelaxAndSport.Domain.Booking.Factories.MassagesAppointments
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Common.Models;
    using System;

    public class MassagesAppointmentsFactory : IMassagesAppointmentsFactory
    {
        private Massage massage = default!;
        private DateTimeRange timeRange = default!;

        private bool massageSet = false;
        private bool timeRangeSet = false;


        public IMassagesAppointmentsFactory WithMassage(Massage massage)
        {
            this.massage = massage;
            this.massageSet = true;

            return this;
        }

        public IMassagesAppointmentsFactory WithTimeRange(DateTime startDate, int duration)
            => this.WithTimeRange(new DateTimeRange(startDate, TimeSpan.FromMinutes(duration)));

        public IMassagesAppointmentsFactory WithTimeRange(DateTimeRange timeRange)
        {
            this.timeRange = timeRange;
            this.timeRangeSet = true;

            return this;
        }

        public MassageAppointment Build()
        {
            if(
                !this.massageSet ||
                !this.timeRangeSet)
            {
                throw new InvalidMassageAppointmentException("Massage and time range must have a value.");
            }

            return new MassageAppointment(
                this.massage,
                this.timeRange);
        }
    }
}
