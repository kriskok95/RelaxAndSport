namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.Massages.Commands.Create;
    using RelaxAndSport.Application.Booking.Massages.Queries.Common;
    using RelaxAndSport.Application.Booking.Massages.Queries.Details;
    using RelaxAndSport.Web.Common;
    using System.Threading.Tasks;

    public class MassagesController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<MassageOutputModel>> Details(
            [FromRoute] MassageDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateMassageOutputModel>> Create(CreateMassageCommand command)
            => await this.Send(command);
    }
}
