namespace RelaxAndSport.Infrastructure.Booking.Configuration.Massages
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.Massages;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;
    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Massage;

    public class MassageConfiguration : IEntityTypeConfiguration<Massage>
    {
        public void Configure(EntityTypeBuilder<Massage> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Category)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType("decimal(18,4)");
        }
    }
}
