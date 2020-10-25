namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.Massages.Commands.Create;
    using RelaxAndSport.Application.Booking.Massages.Commands.Delete;
    using RelaxAndSport.Application.Booking.Massages.Commands.Edit;
    using RelaxAndSport.Application.Booking.Massages.Queries.All;
    using RelaxAndSport.Application.Booking.Massages.Queries.Common;
    using RelaxAndSport.Application.Booking.Massages.Queries.Details;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Web.Common;
    using RelaxAndSport.Web.Common.Attributes;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MassagesController : ApiController
    {
        [HttpGet]
        [Route(nameof(All))]
        public async Task<ActionResult<IEnumerable<MassageOutputModel>>> All([FromQuery] AllMassagesDetailsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<MassageOutputModel>> Details(
            [FromRoute] MassageDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [AuthorizeAdministrator]
        public async Task<ActionResult<CreateMassageOutputModel>> Create(CreateMassageCommand command)
            => await this.Send(command);

        [HttpPut]
        [AuthorizeAdministrator]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditMassageCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [AuthorizeAdministrator]
        [Route(Id)]
        public async Task<ActionResult> Delete([FromRoute] DeleteMassageCommand command)
            => await this.Send(command);
    }
}
