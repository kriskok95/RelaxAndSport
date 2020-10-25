namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Statistics.Commands.Get;
    using RelaxAndSport.Web.Common;
    using System.Threading.Tasks;

    public class StatisticsController : ApiController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GetStatisticsOutputModel>> Get([FromQuery] GetStatisticsQuery command)
            => await this.Send(command);
    }
}
