namespace RelaxAndSport.Domain.Booking.Factories.TrainingsAppointmentsFactory
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Common.Models;
    using System;

    public class TrainingsAppointmentsFactory : ITrainingsAppointmentsFactory
    {
        private Training training = default!;
        private DateTimeRange timeRange = default!;

        private bool trainingSet = false;
        private bool timeRangeSet = false;

        public ITrainingsAppointmentsFactory WithTraining(Training training)
        {
            this.training = training;
            this.trainingSet = true;

            return this;
        }

        public ITrainingsAppointmentsFactory WithTimeRange(DateTime startDate, int duration)
            => this.WithTimeRange(new DateTimeRange(startDate, TimeSpan.FromMinutes(duration)));

        public ITrainingsAppointmentsFactory WithTimeRange(DateTimeRange timeRange)
        {
            this.timeRange = timeRange;
            this.timeRangeSet = true;

            return this;
        }

        public TrainingAppointment Build()
        {
            if(
                !this.trainingSet ||
                !this.timeRangeSet)
            {
                throw new InvalidTrainingAppointmentException("Training and time range must have a value.");
            }

            return new TrainingAppointment(
                this.training,
                this.timeRange);
        }
    }
}
