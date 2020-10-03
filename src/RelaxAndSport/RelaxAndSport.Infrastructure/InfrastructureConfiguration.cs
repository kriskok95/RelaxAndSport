namespace RelaxAndSport.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Infrastructure.Booking;
    using RelaxAndSport.Infrastructure.Common;
    using RelaxAndSport.Infrastructure.Common.Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration)
           => services
               .AddDatabase(configuration)
               .AddRepositories();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<RelaxAndSportDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(RelaxAndSportDbContext).Assembly.FullName)))
                .AddScoped<IBookingDbContext>(provider => provider.GetService<RelaxAndSportDbContext>())
                .AddTransient<IInitializer, DatabaseInitializer>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRepository<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
    }
}
