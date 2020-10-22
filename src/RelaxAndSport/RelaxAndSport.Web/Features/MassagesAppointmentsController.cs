namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Commands.CreateMassageAppointment;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Commands.DeleteMassageAppointment;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Commands.Edit;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Queries.Common;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Queries.GetByDate;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Web.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MassagesAppointmentsController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("{Date}")]
        public async Task<ActionResult<IEnumerable<MassageAppointmentOutputModel>>> GetMassagesAppointmentsByDate(
            DateTime date,
            [FromRoute] GetMassagesAppointmentsByDateQuery command)
            => await this.Send(command);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateMassageAppointmentOutputModel>> Create(CreateMassageAppointmentCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<Result>> Edit(int id, EditMassageAppointmentCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<Result>> Delete([FromRoute] DeleteMassageAppointmentComand command)
            => await this.Send(command);
    }
}
