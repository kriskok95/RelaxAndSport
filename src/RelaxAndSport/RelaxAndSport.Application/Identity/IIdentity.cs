namespace RelaxAndSport.Application.Identity
{
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Identity.Commands.ChangePassword;
    using RelaxAndSport.Application.Identity.Commands.CreateUser;
    using RelaxAndSport.Application.Identity.Commands.LoginUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(CreateUserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(LoginInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
