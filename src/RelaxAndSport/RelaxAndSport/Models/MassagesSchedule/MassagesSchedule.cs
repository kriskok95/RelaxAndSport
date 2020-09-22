namespace RelaxAndSport.Domain.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class MassagesSchedule : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<MassageAppointment> massageAppointments;

        internal MassagesSchedule()
        {
            this.massageAppointments = new HashSet<MassageAppointment>();
        }

        public IReadOnlyCollection<MassageAppointment> MassageAppointments => this.massageAppointments
            .ToList()
            .AsReadOnly();
    }
}
