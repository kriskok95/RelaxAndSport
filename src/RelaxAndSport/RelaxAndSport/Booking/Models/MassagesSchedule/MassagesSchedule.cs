namespace RelaxAndSport.Domain.Booking.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MassagesSchedule : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<MassageAppointment> massageAppointments;

        internal MassagesSchedule()
        {
            massageAppointments = new HashSet<MassageAppointment>();
        }

        public IReadOnlyCollection<MassageAppointment> MassageAppointments => massageAppointments
            .ToList()
            .AsReadOnly();
    }
}
