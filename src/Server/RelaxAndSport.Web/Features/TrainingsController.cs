namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Create;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Delete;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Edit;
    using RelaxAndSport.Application.Booking.Trainings.Queries.All;
    using RelaxAndSport.Application.Booking.Trainings.Queries.Details;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Web.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TrainingsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingOutputModel>>> GetAll([FromQuery] GetAllTrainingsQuery command)
            => await this.Send(command);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<TrainingOutputModel>> Details(int id, [FromRoute] TrainingDetailsQuery command)
            => await this.Send(command.SetId(id));

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateTrainingOutputModel>> Create(CreateTrainingCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditTrainingCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id, [FromQuery] DeleteTrainingCommand command)
            => await this.Send(command.SetId(id));
    }
}
