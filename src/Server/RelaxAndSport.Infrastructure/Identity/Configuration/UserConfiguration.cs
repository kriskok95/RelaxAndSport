namespace RelaxAndSport.Infrastructure.Identity.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Email)
                .IsRequired();

            builder
                .Property(u => u.FirstName)
                .IsRequired();

            builder
                .Property(u => u.LastName)
                .IsRequired();
        }
    }
}
