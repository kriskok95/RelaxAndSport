namespace RelaxAndSport.Domain.Models.TrainingAppointment
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;

    using static ModelConstants.Common;

    public class Trainer : Entity<int>
    {
        internal Trainer(
            string firstName,
            string lastName)
        {
            this.Validate(firstName, lastName);

            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        private void Validate(string firstName, string lastName)
        {
            this.ValidateFirstName(firstName);
            this.ValidateLastName(lastName);
        }

        private void ValidateFirstName(string firstName)
            => Guard.ForStringLength<InvalidTrainingException>(
                firstName,
                MinNameLength,
                MaxNameLength,
                nameof(firstName));

        private void ValidateLastName(string lastName)
            => Guard.ForStringLength<InvalidTrainingException>(
                lastName,
                MinNameLength,
                MaxNameLength,
                nameof(lastName));
    }
}
