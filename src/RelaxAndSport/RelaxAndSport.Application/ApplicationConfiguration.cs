namespace RelaxAndSport.Application
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Common.Behaviours;
    using System.Reflection;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        => services
                .Configure<ApplicationSettings>(
                    configuration.GetSection(nameof(ApplicationSettings)),
                    options => options.BindNonPublicProperties = true)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddEventHandlers()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        private static IServiceCollection AddEventHandlers(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
