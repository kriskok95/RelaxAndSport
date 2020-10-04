﻿namespace RelaxAndSport.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Identity;
    using RelaxAndSport.Application.Identity.Commands.CreateUser;
    using System.Linq;
    using System.Threading.Tasks;

    public class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "InvalidCredentials";

        private readonly UserManager<User> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<IUser>> Register(CreateUserInputModel userInput)
        {
            var user = new User(
                userInput.FirstName,
                userInput.LastName,
                userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded ?
                Result<IUser>.SuccessWith(user) :
                Result<IUser>.Failure(errors);
        }
    }
}
