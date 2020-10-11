namespace RelaxAndSport.Application.Booking.Massages.Commands.Edit
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Massages.Commands.Common;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditMassageCommand : MassageCommand<EditMassageCommand>, IRequest<Result>
    {
        public class EditMassageHandler : IRequestHandler<EditMassageCommand, Result>
        {
            private readonly IMassagesRepository massagesRepository;

            public EditMassageHandler(IMassagesRepository massagesRepository)
                => this.massagesRepository = massagesRepository;

            public async Task<Result> Handle(EditMassageCommand request, CancellationToken cancellationToken)
            {
                var massage = await this.massagesRepository
                    .Find(request.Id);

                if(massage == null)
                {
                    return $"Massages with Id: {request.Id} doesn't exists.";
                }

                massage
                    .UpdateCategory(request.Category)
                    .UpdateDescription(request.Description)
                    .UpdateDuration(request.Duration)
                    .UpdatePrice(request.Price);

                await this.massagesRepository
                    .Save(massage, cancellationToken);

                return Result.Success;
            }
        }
    }
}
