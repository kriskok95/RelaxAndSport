namespace RelaxAndSport.Domain.TrainingsBooking.Models.TrainingSchedule
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.TrainingsBooking.Exceptions;
    using RelaxAndSport.Domain.TrainingsBooking.Models.Trainings;
    using System;

    public class TrainingAppointment : Entity<int>, IAggregateRoot
    {
        internal TrainingAppointment(
            Training training,
            DateTime date)
        {
            Validate(date);

            Training = training;
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
