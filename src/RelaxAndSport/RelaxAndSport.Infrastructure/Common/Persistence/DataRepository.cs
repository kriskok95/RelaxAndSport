﻿namespace RelaxAndSport.Infrastructure.Common.Persistence
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class DataRepository<TDbContext, TEntity> : Application.Common.Contracts.IQueryRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
