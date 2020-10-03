namespace RelaxAndSport.Domain.Booking.Models.TrainingsSchedule
{
    using RelaxAndSport.Domain.Common;
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
    }
}
