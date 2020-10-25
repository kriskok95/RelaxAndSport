namespace RelaxAndSport.Domain.Booking.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Booking.Events;
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
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

        public MassageAppointment AddMassageAppointment(MassageAppointment massageAppointment)
        {
            if(this.massageAppointments.Any(ma => ma.Id == massageAppointment.Id))
            {
                throw new InvalidMassageAppointmentException($"Cannot add massage appointment with Id: {massageAppointment.Id} because it already exists in the schedule.");
            }

            this.CheckForOverlapsedMassageAppointment(massageAppointment);
            this.massageAppointments.Add(massageAppointment);
            this.RaiseEvent(new MassageAppointmentAddedEvent());

            return massageAppointment;
        }

        public void RemoveMassageAppointment(MassageAppointment massageAppointment)
        {
            if(!this.massageAppointments.Any(ma => ma.Id == massageAppointment.Id))
            {
                throw new InvalidMassageAppointmentException($"Massage appointment with Id: {massageAppointment.Id} doesn't exists.");
            }

            this.massageAppointments.Remove(massageAppointment);
            this.RaiseEvent(new MassageAppointmentRemovedEvent());
        }

        private void CheckForOverlapsedMassageAppointment(MassageAppointment massageAppointment)
        {
            var isOverlapsed = this.massageAppointments
                .Any(ma => ma.TimeRange.Overlaps(massageAppointment.TimeRange));

            if (isOverlapsed)
            {
                throw new InvalidMassageAppointmentException($"Massage appointment at {massageAppointment.TimeRange.Start} can't be added because it overlaps another scheduled massage appointment");
            }
        }
    }
}
