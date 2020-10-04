namespace RelaxAndSport.Domain.Booking.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Common.Models;

    public class MassageAppointment : Entity<int>
    {
        internal MassageAppointment(
            Massage massage,
            DateTimeRange timeRange)
        {
            this.Massage = massage;
            this.TimeRange = timeRange;
        }

        private MassageAppointment()
        {
            this.Massage = default!;
            this.TimeRange = default!;
        }

        public Massage Massage { get; private set; }

        public DateTimeRange TimeRange { get; private set; }
    }
}
