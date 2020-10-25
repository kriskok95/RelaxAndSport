namespace RelaxAndSport.Application.Identity.Commands.LoginUser
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginUserCommand : LoginInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;

            public LoginUserCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                return new LoginOutputModel(user.Token, user.UserId);
            }
        }
    }
}
