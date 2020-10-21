namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Create;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.Common;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.GetByDate;
    using RelaxAndSport.Web.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TrainingsAppointmentsController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("{Date}")]
        public async Task<ActionResult<IEnumerable<TrainingAppointmentOutputModel>>> GetByDate(
            DateTime date,
            [FromRoute] GetTrainingsAppointmentsByDateQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateTrainingAppointmentOutputModel>> Create(CreateTrainingAppointmentCommand command)
            => await this.Send(command);
    }
}
