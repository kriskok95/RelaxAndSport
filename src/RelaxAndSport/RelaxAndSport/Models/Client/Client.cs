namespace RelaxAndSport.Domain.Models.Client
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;
    using RelaxAndSport.Domain.Models.Massages;
    using RelaxAndSport.Domain.Models.TrainingAppointment;
    using System.Collections.Generic;
    using System.Linq;
    using static ModelConstants.Common;

    public class Client : Entity<int>
    {
        private readonly HashSet<MassageAppointment> massageAppointments;
        private readonly HashSet<TrainingAppointment> trainingAppointments;

        internal Client(
            string firstName,
            string lastName,
            PhoneNumber phoneNumber)
        {
            this.Validate(firstName, lastName);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;

            this.massageAppointments = new HashSet<MassageAppointment>();
            this.trainingAppointments = new HashSet<TrainingAppointment>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public IReadOnlyCollection<MassageAppointment> MassageAppointments => this.massageAppointments
            .ToList()
            .AsReadOnly();

        public IReadOnlyCollection<TrainingAppointment> TrainingAppointments => this.trainingAppointments
            .ToList()
            .AsReadOnly();

        private void Validate(string firstName, string lastName)
        {
            this.ValidateFirstName(firstName);
            this.ValidateLastName(lastName);
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
