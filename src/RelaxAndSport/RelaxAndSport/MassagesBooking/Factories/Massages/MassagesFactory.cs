using RelaxAndSport.Domain.MassagesBooking.Exceptions;
using RelaxAndSport.Domain.MassagesBooking.Models.Massages;

namespace RelaxAndSport.Domain.MassagesBooking.Factories.Massages
{
    internal class MassagesFactory : IMassagesFactory
    {
        private Type type = default!;
        private int duration = default;
        private decimal price = default;

        private bool typeSet = false;
        private bool durationSet = false;
        private bool priceSet = false;

        public IMassagesFactory WithType(string name, string description)
            => this.WithType(new Type(name, description));

        public IMassagesFactory WithType(Type type)
        {
            this.type = type;
            this.typeSet = true;
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
            if (!this.typeSet || !this.durationSet || ! this.priceSet)
            {
                throw new InvalidMassageException("Massage type, duration and price must have a value.");
            }

            return new Massage(
                this.type,
                this.duration,
                this.price);
        }
    }
}
