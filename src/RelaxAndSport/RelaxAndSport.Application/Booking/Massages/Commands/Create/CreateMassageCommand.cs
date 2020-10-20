namespace RelaxAndSport.Application.Booking.Massages.Commands.Create
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Massages.Commands.Common;
    using RelaxAndSport.Domain.Booking.Factories.Massages;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateMassageCommand : MassageCommand<CreateMassageCommand>, IRequest<CreateMassageOutputModel>
    {
        public class CreateMassageCommandHandler : IRequestHandler<CreateMassageCommand, CreateMassageOutputModel>
        {
            private readonly IMassagesFactory massagesFactory;
            private readonly IMassagesDomainRepository massagesRepository;

            public CreateMassageCommandHandler(
                IMassagesFactory massagesFactory,
                IMassagesDomainRepository massagesRepository)
            {
                this.massagesFactory = massagesFactory;
                this.massagesRepository = massagesRepository;
            }
            
            public async Task<CreateMassageOutputModel> Handle(CreateMassageCommand request, CancellationToken cancellationToken)
            {
                var massage = massagesFactory
                    .WithCategory(request.Category)
                    .WithDescription(request.Description)
                    .WithDuration(request.Duration)
                    .WithPrice(request.Price)
                    .Build();

                await this.massagesRepository.Save(massage, cancellationToken);

                return new CreateMassageOutputModel(massage.Id);
            }
        }
    }
}
