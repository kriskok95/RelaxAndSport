namespace RelaxAndSport.Domain.Booking.Factories.Client
{
    using RelaxAndSport.Domain.Booking.Models.Client;
    using RelaxAndSport.Domain.Common.Exceptions;

    public class ClientFactory : IClientFactory
    {
        private string userId = default!;
        private string firstName = default!;
        private string lastName = default!;
        private string phoneNumber = default!;

        private bool userIdSet = false;
        private bool firstNameSet = false;
        private bool lastNameSet = false;
        private bool phoneNumberSet = false;

        public IClientFactory WithUserId(string userId)
        {
            this.userId = userId;
            this.userIdSet = true;

            return this;
        }

        public IClientFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;
            this.firstNameSet = true;

            return this;
        }

        public IClientFactory WithLastName(string lastName)
        {
            this.lastName = lastName;
            this.lastNameSet = true;

            return this;
        }

        public IClientFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            this.phoneNumberSet = true;

            return this;
        }

        public Client Build()
        {
            if(
                !this.userIdSet ||
                !this.firstNameSet ||
                !this.lastNameSet ||
                !this.phoneNumberSet)
            {
                throw new InvalidClientException("A user must have userId, first name, last name and phone number.");
            }

            return new Client(
                this.userId,
                this.firstName,
                this.lastName,
                this.phoneNumber);
        }
    }
}
