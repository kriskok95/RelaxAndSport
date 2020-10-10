namespace RelaxAndSport.Application.Booking.Massages.Queries.Details
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Massages.Queries.Common;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class MassageDetailsQuery : EntityCommand<int>, IRequest<MassageOutputModel>
    {
        public class MassageDetailsHandler : IRequestHandler<MassageDetailsQuery, MassageOutputModel>
        {
            private readonly IMassagesRepository massagesRepository;

            public MassageDetailsHandler(IMassagesRepository massagesRepository)
                => this.massagesRepository = massagesRepository;
            

            public Task<MassageOutputModel> Handle(MassageDetailsQuery request, CancellationToken cancellationToken)
            {
                var massageDetails = massagesRepository.GetDetails(request.Id, cancellationToken);

                return massageDetails;
            }
        }
    }
}
