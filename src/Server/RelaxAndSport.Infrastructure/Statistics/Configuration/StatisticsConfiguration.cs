namespace RelaxAndSport.Infrastructure.Statistics.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Statistics.Models;

    public class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            const string Id = "Id";

            builder
                .Property<int>(Id);

            builder
                .HasKey(Id);
        }
    }
}
