namespace RelaxAndSport.Domain.Booking.Models.TrainingsSchedule
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;
    using System;

    public class TrainingAppointment : Entity<int>
    {
        internal TrainingAppointment(
            Training training,
            DateTimeRange timeRange)
        {
            this.Training = training;
            this.TimeRange = timeRange;
        }

        internal TrainingAppointment()
        {
            this.Training = default!;
            this.TimeRange = default!;
        }

        public Training Training { get; private set; }

        public DateTimeRange TimeRange { get; private set; }
    }
}
