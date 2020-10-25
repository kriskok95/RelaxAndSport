namespace RelaxAndSport.Application.Statistics.Commands.Get
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetStatisticsQuery : EntityCommand<int>, IRequest<GetStatisticsOutputModel>
    {
        public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, GetStatisticsOutputModel>
        {
            private readonly IStatisticsQueryRepository statisticsRepository;

            public GetStatisticsQueryHandler(IStatisticsQueryRepository statisticsRepository)
                => this.statisticsRepository = statisticsRepository;

            public async Task<GetStatisticsOutputModel> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
                 => await this.statisticsRepository.GetStatisticsOutputModel(cancellationToken);
        }
    }
}
