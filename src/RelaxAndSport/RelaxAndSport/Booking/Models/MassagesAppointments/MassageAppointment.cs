namespace RelaxAndSport.Domain.Booking.Models.MassagesAppointments
{
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;
    using System;

    public class MassageAppointment : Entity<int>, IAggregateRoot
    {
        internal MassageAppointment(
            Massage massage,
            DateTimeRange timeRange)
        {
            Massage = massage;
            TimeRange = timeRange;
        }

        private MassageAppointment()
        {
            Massage = default!;
            TimeRange = default!;
        }

        public Massage Massage { get; private set; }

        public DateTimeRange TimeRange { get; private set; }

        public MassageAppointment UpdateMassage(Massage massage)
        {
            this.Massage = massage;

            return this;
        }

        public MassageAppointment UpdateTimeRange(DateTime startDate)
        {
            this.TimeRange = new DateTimeRange(startDate, TimeSpan.FromMinutes(this.Massage.Duration));

            return this;
        }
    }
}
