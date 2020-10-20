namespace RelaxAndSport.Application.Common.Contracts
{
    using RelaxAndSport.Domain.Common;
    public interface IQueryRepository<in TEntity>
       where TEntity : IAggregateRoot
    {
    }
}
