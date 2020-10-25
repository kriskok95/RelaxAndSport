namespace RelaxAndSport.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Identity;
    using RelaxAndSport.Application.Identity.Commands.ChangePassword;
    using RelaxAndSport.Application.Identity.Commands.CreateUser;
    using RelaxAndSport.Application.Identity.Commands.LoginUser;
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

            if (identityResult.Succeeded)
            {
                var userData = await this.userManager.FindByEmailAsync(userInput.Email);
                user.Id = userData.Id;
            }

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded ?
                Result<IUser>.SuccessWith(user) :
                Result<IUser>.Failure(errors);
        }

        public async Task<Result<LoginSuccessModel>> Login(LoginInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var token = this.jwtTokenGenerator.GenerateToken(user, roles);

            return new LoginSuccessModel(user.Id, token);
        }

        public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(changePasswordInput.UserId);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
    }
}
