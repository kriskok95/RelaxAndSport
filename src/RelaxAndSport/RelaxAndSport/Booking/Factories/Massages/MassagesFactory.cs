namespace RelaxAndSport.Domain.Booking.Factories.Massages
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.Massages;

    internal class MassagesFactory : IMassagesFactory
    {
        private string category = default!;
        private string description = default!;
        private int duration = default;
        private decimal price = default;

        private bool categorySet = false;
        private bool descriptionSet = false;
        private bool typeSet = false;
        private bool durationSet = false;
        private bool priceSet = false;

        public IMassagesFactory WithCategory(string category)
        {
            this.category = category;
            this.categorySet = true;
            return this;
        }

        public IMassagesFactory WithDescription(string description)
        {
            this.description = description;
            this.descriptionSet = true;
            return this;
        }

        public IMassagesFactory WithDuration(int duration)
        {
            this.duration = duration;
            this.durationSet = true;
            return this;
        }

        public IMassagesFactory WithPrice(decimal price)
        {
            this.price = price;
            this.priceSet = true;
            return this;
        }

        public Massage Build()
        {
            if (
                !this.categorySet ||
                !this.descriptionSet ||
                !this.typeSet || 
                !this.durationSet || 
                ! this.priceSet)
            {
                throw new InvalidMassageException("Massage type, duration and price must have a value.");
            }

            return new Massage(
                this.category,
                this.description,
                this.duration,
                this.price);
        }
    }
}
