namespace RelaxAndSport.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : CreateUserInputModel, IRequest<Result>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
                => await this.identity.Register(request);
        }
    }
}
