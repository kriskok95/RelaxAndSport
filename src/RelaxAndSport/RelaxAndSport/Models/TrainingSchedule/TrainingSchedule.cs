namespace RelaxAndSport.Domain.Models.TrainingSchedule
{
    using RelaxAndSport.Domain.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class TrainingSchedule : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<TrainingAppointment> trainingAppointments;

        internal TrainingSchedule()
        {
            this.trainingAppointments = new HashSet<TrainingAppointment>();
        }

        public IReadOnlyCollection<TrainingAppointment> TrainingAppointments => this.trainingAppointments
            .ToList()
            .AsReadOnly();
    }
}
