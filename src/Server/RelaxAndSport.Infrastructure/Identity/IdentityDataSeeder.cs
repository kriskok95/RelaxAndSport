namespace RelaxAndSport.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using RelaxAndSport.Domain.Booking.Factories.Client;
    using RelaxAndSport.Domain.Booking.Repositories;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Linq;
    using System.Threading.Tasks;

    using static RelaxAndSport.Infrastructure.Common.Constants.InfrastructureConstants.IdentityConstants;

    internal class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IClientFactory clientFactory;
        private readonly IClientDomainRepository clientRepository;

        public IdentityDataSeeder(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IClientFactory clientFactory,
            IClientDomainRepository clientRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.clientFactory = clientFactory;
            this.clientRepository = clientRepository;
        }

        public void SeedData()
        {
            if (!this.roleManager.Roles.Any())
            {
                Task
                    .Run(async () =>
                    {
                        var adminRole = new IdentityRole(AdministratorRoleName);

                        await this.roleManager.CreateAsync(adminRole);

                        var adminUser = new User("admin", "admin", "admin@gmail.com");

                        var adminPassword = "123456";

                        await this.userManager.CreateAsync(adminUser, adminPassword);

                        await this.userManager.AddToRoleAsync(adminUser, AdministratorRoleName);

                        var client = this.clientFactory
                            .WithFirstName(adminUser.FirstName)
                            .WithLastName(adminUser.LastName)
                            .WithPhoneNumber("+3593243243")
                            .WithUserId(adminUser.Id)
                            .Build();

                        await this.clientRepository.Save(client);

                    })
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
