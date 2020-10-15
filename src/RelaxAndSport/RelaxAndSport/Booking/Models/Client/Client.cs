namespace RelaxAndSport.Domain.Booking.Models.Client
{
    using RelaxAndSport.Domain.Booking.Events;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Exceptions;
    using RelaxAndSport.Domain.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;

    public class Client : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<MassageAppointment> massageAppointments;
        private readonly HashSet<TrainingAppointment> trainingAppointments;

        internal Client(
            string userId,
            string firstName,
            string lastName,
            PhoneNumber phoneNumber)
        {
            this.Validate(firstName, lastName);

            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;

            this.massageAppointments = new HashSet<MassageAppointment>();
            this.trainingAppointments = new HashSet<TrainingAppointment>();
        }

        private Client(
            string firstName,
            string lastName,
            string userId)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = default!;

            this.massageAppointments = new HashSet<MassageAppointment>();
            this.trainingAppointments = new HashSet<TrainingAppointment>();
        }

        public string UserId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }

        public PhoneNumber PhoneNumber { get; private set; }

        public IReadOnlyCollection<MassageAppointment> MassageAppointments => massageAppointments
            .ToList()
            .AsReadOnly();

        public IReadOnlyCollection<TrainingAppointment> TrainingAppointments => trainingAppointments
            .ToList()
            .AsReadOnly();

        public Client UpdateFirstName(string firstName)
        {
            this.ValidateFirstName(firstName);
            this.FirstName = firstName;

            return this;
        }

        public Client UpdateLastName(string lastName)
        {
            this.ValidateLastName(lastName);
            this.LastName = lastName;

            return this;
        }

        public Client UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public MassageAppointment AddMassageAppointment(MassageAppointment massageAppointment)
        {
            this.massageAppointments.Add(massageAppointment);

            return massageAppointment;
        }

        public void RemoveMassageAppointment(MassageAppointment massageAppointment)
        {
            if(!this.massageAppointments.Any(ma => ma.Id == massageAppointment.Id))
            {
                throw new InvalidClientException($"{this.FullName} doesn't have massage appointment with Id: {massageAppointment.Id}.");
            }

            this.massageAppointments.Remove(massageAppointment);
            this.RaiseEvent(new MassageAppointmentRemovedEvent());
        } 

        public void AddTrainingAppointment(TrainingAppointment trainingAppointment)
        {
            this.trainingAppointments.Add(trainingAppointment);
            this.RaiseEvent(new TrainingAppointmentAddedEvent());
        }

        public void RemoveTrainingAppointment(TrainingAppointment trainingAppointment)
        {
            if(!this.trainingAppointments.Any(ta => ta.Id == trainingAppointment.Id))
            {
                throw new InvalidClientException($"{this.FullName} doesn't have training appointment with Id: {trainingAppointment.Id}.");
            }

            this.trainingAppointments.Remove(trainingAppointment);
            this.RaiseEvent(new TrainingAppointmentRemovedEvent());
        }

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
