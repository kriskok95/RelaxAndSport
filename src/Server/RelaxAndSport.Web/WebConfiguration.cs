namespace RelaxAndSport.Web
{
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Web.Services;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddControllers()
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
