namespace RelaxAndSport.Application.Statistics.Commands.Get
{
    using RelaxAndSport.Application.Common.Mapping;
    using RelaxAndSport.Domain.Statistics.Models;

    public class GetStatisticsOutputModel : IMapFrom<Statistics>
    {
        public int TotalActiveMassageAppointments { get; set; }

        public int TotalActiveTrainingAppointments { get; set; }
    }
}
