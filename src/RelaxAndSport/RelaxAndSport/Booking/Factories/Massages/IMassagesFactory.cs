namespace RelaxAndSport.Domain.Booking.Factories.Massages
{
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Common;

    public interface IMassagesFactory : IFactory<Massage>
    {
        IMassagesFactory WithCategory(string category);

        IMassagesFactory WithDescription(string description);

        IMassagesFactory WithDuration(int duration);

        IMassagesFactory WithPrice(decimal price);
    }
}
