namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.Massages.Commands.Create;
    using RelaxAndSport.Web.Common;
    using System.Threading.Tasks;

    public class MassagesController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateMassageOutputModel>> Create(CreateMassageCommand command)
            => await this.Send(command);
    }
}
