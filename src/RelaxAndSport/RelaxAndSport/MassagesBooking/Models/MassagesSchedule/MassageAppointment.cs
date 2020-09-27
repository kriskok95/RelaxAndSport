namespace RelaxAndSport.Domain.MassagesBooking.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.MassagesBooking.Exceptions;
    using RelaxAndSport.Domain.MassagesBooking.Models.Massages;
    using System;

    public class MassageAppointment : Entity<int>
    {
        internal MassageAppointment(
            Massage massage,
            DateTime startDate,
            DateTime endDate)
        {
            Validate(startDate, endDate);

            Massage = massage;
            this.StartDate = startDate;
            this.EndDate = EndDate;
        }

        public Massage Massage { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        private void Validate(DateTime startDate, DateTime endDate)
        {
            ValidateStartDate(startDate);
            ValidateEndDate(endDate);
        }

        private void ValidateStartDate(DateTime date)
            => Guard.ForValidDate<IvalidMassageAppointmentException>(date);

        private void ValidateEndDate(DateTime endDate)
            => Guard.AgainstDateRange<InvalidMassageException>(
                endDate, 
                this.StartDate,
                nameof(endDate));
    }
}
