namespace RelaxAndSport.Infrastructure.Statistics
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Domain.Statistics.Models;
    using RelaxAndSport.Infrastructure.Common.Persistence;

    public interface IStatisticsDbContext : IDbContext
    {
        DbSet<Statistics> Statistics { get; }
    }
}
