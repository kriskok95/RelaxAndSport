namespace RelaxAndSport.Application.Identity
{
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Identity.Commands.CreateUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(CreateUserInputModel userInput);

        //Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        //Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
