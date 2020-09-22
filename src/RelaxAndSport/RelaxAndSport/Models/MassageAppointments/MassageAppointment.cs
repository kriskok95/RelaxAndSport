namespace RelaxAndSport.Domain.Models.Massages
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;
    using RelaxAndSport.Domain.Models.MassageAppointments;
    using System;

    public class MassageAppointment : Entity<int>
    {
        internal MassageAppointment(
            Massage massage,
            DateTime date)
        {
            this.Validate(date);

            this.Massage = massage;
            this.Date = date;
        }

        public Massage Massage { get; private set; }

        public DateTime Date { get; private set; }

        private void Validate(DateTime date)
        {
            this.ValidateDate(date);
        }

        private void ValidateDate(DateTime date)
            => Guard.ForValidDate<IvalidMassageAppointmentException>(date);
    }
}
