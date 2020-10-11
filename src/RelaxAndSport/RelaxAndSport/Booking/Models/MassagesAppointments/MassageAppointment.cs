namespace RelaxAndSport.Domain.Booking.Models.MassagesAppointments
{
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;

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
    }
}
