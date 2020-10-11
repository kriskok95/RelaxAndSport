namespace RelaxAndSport.Application.Booking.Massages.Commands.Delete
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteMassageCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteMassageCommandHandler : IRequestHandler<DeleteMassageCommand, Result>
        {
            private readonly IMassagesRepository massagesRepository;

            public DeleteMassageCommandHandler(IMassagesRepository massagesRepository)
                => this.massagesRepository = massagesRepository;

            public async Task<Result> Handle(DeleteMassageCommand request, CancellationToken cancellationToken)
            {
                var contatinsMassage = await this.massagesRepository
                    .HasMassage(request.Id, cancellationToken);

                if(!contatinsMassage)
                {
                    return $"Massage with Id: {request.Id} doesn't exists.";
                }

                return await this.massagesRepository
                    .Delete(request.Id, cancellationToken);
            }
        }
    }
}
