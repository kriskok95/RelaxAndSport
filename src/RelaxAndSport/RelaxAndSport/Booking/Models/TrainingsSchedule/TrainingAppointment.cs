namespace RelaxAndSport.Domain.Booking.Models.TrainingsSchedule
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Common;
    using System;

    public class TrainingAppointment : Entity<int>
    {
        internal TrainingAppointment(
            Training training,
            DateTime date)
        {
            Validate(date);

            Training = training;
            Date = date;
        }

        internal TrainingAppointment(
            DateTime date)
        {
            Training = default!;
            Date = date;
        }

        public Training Training { get; private set; }

        public DateTime Date { get; private set; }

        private void Validate(DateTime date)
        {
            ValidateDate(date);
        }

        private void ValidateDate(DateTime date)
            => Guard.ForValidDate<InvalidTrainingAppointmentException>(date);
    }
}
