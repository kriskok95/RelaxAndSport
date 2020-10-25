namespace RelaxAndSport.Application.Booking.Massages.Queries.All
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Massages.Queries.Common;
    using RelaxAndSport.Application.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class AllMassagesDetailsQuery : EntityCommand<int>, IRequest<IEnumerable<MassageOutputModel>>
    {
        public class AllMassagesDetailsQueryHandler : IRequestHandler<AllMassagesDetailsQuery, IEnumerable<MassageOutputModel>>
        {
            IMassagesQueryRepository massagesRepository;

            public AllMassagesDetailsQueryHandler(IMassagesQueryRepository massagesRepository)
                => this.massagesRepository = massagesRepository;

            public async Task<IEnumerable<MassageOutputModel>> Handle(AllMassagesDetailsQuery request, CancellationToken cancellationToken)
            {
                var allMassagesDetails = await this.massagesRepository
                    .GetAllMassagesDetails(cancellationToken);

                return allMassagesDetails;
            }
        }
    }
}
