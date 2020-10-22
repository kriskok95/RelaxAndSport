namespace RelaxAndSport.Domain.Booking.Models.TrainingsSchedule
{
    using RelaxAndSport.Domain.Booking.Events;
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class TrainingsSchedule : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<TrainingAppointment> trainingAppointments;

        internal TrainingsSchedule()
        {
            this.trainingAppointments = new HashSet<TrainingAppointment>();
        }

        public IReadOnlyCollection<TrainingAppointment> TrainingAppointments => this.trainingAppointments
            .ToList()
            .AsReadOnly();

        public TrainingAppointment AddTrainingAppointment(TrainingAppointment trainingAppointment)
        {
            if (this.trainingAppointments.Any(ta => ta.Id == trainingAppointment.Id))
            {
                throw new InvalidTrainingAppointmentException($"Training appointment with Id: {trainingAppointment} already exists in the schedule.");
            }
            this.CheckForOverlapsedTrainingAppointment(trainingAppointment);
            this.trainingAppointments.Add(trainingAppointment);
            this.RaiseEvent(new TrainingAppointmentAddedEvent());

            return trainingAppointment;
        }

        public void RemoveTrainingAppointment(TrainingAppointment trainingAppointment)
        {
            if(!this.trainingAppointments.Any(ta => ta.Id == trainingAppointment.Id))
            {
                throw new InvalidTrainingAppointmentException($"Can't remove training appointment with Id: {trainingAppointment.Id} because it doesn't exists in the schedule.");
            }
            this.trainingAppointments.Remove(trainingAppointment);
            this.RaiseEvent(new TrainingAppointmentRemovedEvent());
        }

        private void CheckForOverlapsedTrainingAppointment(TrainingAppointment trainingAppointment)
        {
            var isOverlapsed = this.trainingAppointments
                .Any(ma => ma.TimeRange.Overlaps(trainingAppointment.TimeRange));

            if (isOverlapsed)
            {
                throw new InvalidTrainingAppointmentException($"Training appointment with id {trainingAppointment.Id} can't be added because it overlaps another training appointment");
            }
        }
    }
}
