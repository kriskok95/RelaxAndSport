namespace RelaxAndSport.Infrastructure.Booking.Configuration.Client
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RelaxAndSport.Domain.Booking.Models.Client;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;

    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .OwnsOne(
                    c => c.PhoneNumber,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Number);
                    });

            builder
                .HasMany(c => c.MassageAppointments)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("massageAppointments");

            builder
                .HasMany(c => c.TrainingAppointments)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("trainingAppointments");
        }
    }
}
