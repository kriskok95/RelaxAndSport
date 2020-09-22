namespace RelaxAndSport.Domain.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;
    using System;

    public class MassageAppointment : Entity<int>
    {
        internal MassageAppointment(
            Massage massage,
            DateTime date)
        {
            Validate(date);

            Massage = massage;
            Date = date;
        }

        public Massage Massage { get; private set; }

        public DateTime Date { get; private set; }

        private void Validate(DateTime date)
        {
            ValidateDate(date);
        }

        private void ValidateDate(DateTime date)
            => Guard.ForValidDate<IvalidMassageAppointmentException>(date);
    }
}
