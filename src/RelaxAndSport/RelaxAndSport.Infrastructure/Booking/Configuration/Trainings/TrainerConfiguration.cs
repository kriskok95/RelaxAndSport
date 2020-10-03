namespace RelaxAndSport.Infrastructure.Booking.Configuration.Trainings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.Trainings;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;

    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

        }
    }
}
