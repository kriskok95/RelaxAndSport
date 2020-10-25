namespace RelaxAndSport.Domain.Statistics.Models
{
    using RelaxAndSport.Domain.Common;

    public class Statistics : IAggregateRoot
    {
        internal Statistics()
        {
            this.TotalActiveMassageAppointments = 0;
            this.TotalActiveTrainingAppointments = 0;
        }

        public int TotalActiveMassageAppointments { get; private set; }

        public int TotalActiveTrainingAppointments { get; private set; }

        public void AddeMassageAppointment()
            => this.TotalActiveMassageAppointments++;

        public void AddteTrainingAppointment()
            => this.TotalActiveTrainingAppointments++;

        public void RemovedMassageAppointment()
            => this.TotalActiveMassageAppointments--;

        public void RemovedTrainingAppointment()
            => this.TotalActiveTrainingAppointments--;
    }
}
