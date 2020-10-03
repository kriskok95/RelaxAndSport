namespace RelaxAndSport.Domain.Booking.Models.Massages
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Common;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;
    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Massage;

    public class Type : Entity<int>
    {
        internal Type(string name, string description)
        {
            Validate(name, description);

            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        public void Validate(string name, string description)
        {
            ValidateName(name);
            ValidateDescription(description);
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidMassageException>(
                name,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(Name));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidMassageException>(
                description,
                MinNameLength,
                MaxNameLength,
                nameof(Description));
    }
}
