namespace RelaxAndSport.Application.Identity
{
    using RelaxAndSport.Domain.Booking.Models.Client;

    public interface IUser
    {
        void BecomeClient(Client client);
    }
}
