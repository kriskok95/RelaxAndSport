namespace RelaxAndSport.Domain.Booking.Models.Client
{
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Exceptions;
    using System.Collections.Generic;
    using System.Linq;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;

    public class Client : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<MassageAppointment> massageAppointments;
        private readonly HashSet<TrainingAppointment> trainingAppointments;

        internal Client(
            string firstName,
            string lastName,
            PhoneNumber phoneNumber)
        {
            Validate(firstName, lastName);

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;

            massageAppointments = new HashSet<MassageAppointment>();
            trainingAppointments = new HashSet<TrainingAppointment>();
        }

        private Client(
            string firstName,
            string lastName)
        {

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = default!;

            massageAppointments = new HashSet<MassageAppointment>();
            trainingAppointments = new HashSet<TrainingAppointment>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public IReadOnlyCollection<MassageAppointment> MassageAppointments => massageAppointments
            .ToList()
            .AsReadOnly();

        public IReadOnlyCollection<TrainingAppointment> TrainingAppointments => trainingAppointments
            .ToList()
            .AsReadOnly();

        private void Validate(string firstName, string lastName)
        {
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
        }

        private void ValidateFirstName(string firstName)
            => Guard.ForStringLength<InvalidClientException>(
                firstName,
                MinNameLength,
                MaxNameLength,
                nameof(firstName));

        private void ValidateLastName(string lastName)
            => Guard.ForStringLength<InvalidClientException>(
                lastName,
                MinNameLength,
                MaxNameLength,
                nameof(lastName));
    }
}
