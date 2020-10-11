namespace RelaxAndSport.Domain.Booking.Factories.Client
{
    using RelaxAndSport.Domain.Booking.Models.Client;
    using RelaxAndSport.Domain.Common;

    public interface IClientFactory : IFactory<Client>
    {
        IClientFactory WithUserId(string userId);

        IClientFactory WithFirstName(string firstName);

        IClientFactory WithLastName(string lastName);

        IClientFactory WithPhoneNumber(string phoneNumber);
    }
}
