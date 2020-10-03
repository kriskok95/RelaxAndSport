namespace RelaxAndSport.Domain.MassagesBooking.Factories.Massages
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.MassagesBooking.Models.Massages;

    public interface IMassagesFactory : IFactory<Massage>
    {
        IMassagesFactory WithType(string name, string description);

        IMassagesFactory WithType(Type type);

        IMassagesFactory WithDuration(int duration);

        IMassagesFactory WithPrice(decimal price);
    }
}
