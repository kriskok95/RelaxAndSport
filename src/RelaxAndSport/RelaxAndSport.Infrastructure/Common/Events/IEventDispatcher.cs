namespace RelaxAndSport.Infrastructure.Common.Events
{
    using RelaxAndSport.Domain.Common;
    using System.Threading.Tasks;

    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
