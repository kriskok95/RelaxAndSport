namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Create;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Edit;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.Common;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.GetByDate;
    using RelaxAndSport.Application.Common;
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

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<Result>> Edit(int id, EditTrainingAppointmentCommand command)
            => await this.Send(command.SetId(id));
    }
}
