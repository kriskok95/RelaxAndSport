namespace RelaxAndSport.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Client;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Factories.Client;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : CreateUserInputModel, IRequest<Result>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IClientRepository clientRepository;
            private readonly IClientFactory clientFactory;

            public CreateUserCommandHandler(
                IIdentity identity,
                IClientRepository clientRepository,
                IClientFactory clientFactory)
            {
                this.identity = identity;
                this.clientRepository = clientRepository;
                this.clientFactory = clientFactory;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var client = this.clientFactory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                await this.clientRepository.Save(client, cancellationToken);

                return result;
            }
        }
    }
}
