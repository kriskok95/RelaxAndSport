namespace RelaxAndSport.Domain.Booking.Factories.Massages
{
    using RelaxAndSport.Domain.Booking.Models.Massages;
    using RelaxAndSport.Domain.Common;

    public interface IMassagesFactory : IFactory<Massage>
    {
        IMassagesFactory WithType(string name, string description);

        IMassagesFactory WithType(Type type);

        IMassagesFactory WithDuration(int duration);

        IMassagesFactory WithPrice(decimal price);
    }
}
