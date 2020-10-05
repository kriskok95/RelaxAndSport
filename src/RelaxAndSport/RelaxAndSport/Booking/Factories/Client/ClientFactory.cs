namespace RelaxAndSport.Domain.Booking.Factories.Client
{
    using RelaxAndSport.Domain.Booking.Models.Client;

    public class ClientFactory : IClientFactory
    {
        private string firstName = default!;
        private string lastName = default!;
        private string phoneNumber = default!;

        public IClientFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public IClientFactory WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public IClientFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public Client Build()
            => new Client(
                this.firstName,
                this.lastName,
                this.phoneNumber);
    }
}
