namespace RelaxAndSport.Domain.Models.TrainingAppointment
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;
    using System;

    public class TrainingAppointment : Entity<int>
    {
        internal TrainingAppointment(
            Training training,
            DateTime date)
        {
            this.Validate(date);

            this.Training = training;
            this.Date = date;
        }

        public Training Training { get; private set; }

        public DateTime Date { get; private set; }

        private void Validate(DateTime date)
        {
            this.ValidateDate(date);
        }

        private void ValidateDate(DateTime date)
            => Guard.ForValidDate<InvalidTrainingAppointmentException>(date);
            
      
    }
}
