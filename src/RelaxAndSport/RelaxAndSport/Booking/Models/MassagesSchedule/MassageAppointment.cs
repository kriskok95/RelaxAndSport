namespace RelaxAndSport.Domain.Booking.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Common;
    using System;

    public class MassageAppointment : Entity<int>
    {
        internal MassageAppointment(
            Massage massage,
            DateTime startDate)
        {
            Validate(startDate);

            Massage = massage;
            this.StartDate = startDate;
        }

        private MassageAppointment(
            DateTime startDate)
        {
            Validate(startDate);

            Massage = default!;
            this.StartDate = startDate;
        }

        public Massage Massage { get; private set; }

        public DateTime StartDate { get; private set; }


        private void Validate(DateTime startDate)
        {
            ValidateStartDate(startDate);
        }

        private void ValidateStartDate(DateTime date)
            => Guard.ForValidDate<IvalidMassageAppointmentException>(date);
    }
}
