namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Create;
    using RelaxAndSport.Web.Common;
    using System.Threading.Tasks;

    public class TrainingsAppointmentsController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateTrainingAppointmentOutputModel>> Create(CreateTrainingAppointmentCommand command)
            => await this.Send(command);
    }
}
