namespace RelaxAndSport.Application.Common
{
    using RelaxAndSport.Domain.Common;
    using System.Threading.Tasks;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
