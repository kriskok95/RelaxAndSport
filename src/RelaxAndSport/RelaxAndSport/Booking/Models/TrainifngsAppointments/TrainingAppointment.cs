namespace RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments
{
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;

    public class TrainingAppointment : Entity<int>, IAggregateRoot
    {
        internal TrainingAppointment(
            Training training,
            DateTimeRange timeRange)
        {
            Training = training;
            TimeRange = timeRange;
        }

        internal TrainingAppointment()
        {
            Training = default!;
            TimeRange = default!;
        }

        public Training Training { get; private set; }

        public DateTimeRange TimeRange { get; private set; }
    }
}
