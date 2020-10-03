namespace RelaxAndSport.Infrastructure.Identity.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.Client)
                .WithOne()
                .HasForeignKey<User>("ClientId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
