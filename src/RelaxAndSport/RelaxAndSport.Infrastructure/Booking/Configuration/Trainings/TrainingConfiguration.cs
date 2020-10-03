namespace RelaxAndSport.Infrastructure.Booking.Configuration.Trainings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.Trainings;

    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Date)
                .IsRequired();

            builder
                .Property(t => t.Price)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder
                .Property(t => t.Slots)
                .IsRequired();

            builder
                .Property(t => t.Type)
                .IsRequired();
        }
    }
}
