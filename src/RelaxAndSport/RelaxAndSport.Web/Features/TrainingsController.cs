namespace RelaxAndSport.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Create;
    using RelaxAndSport.Application.Booking.Trainings.Queries.All;
    using RelaxAndSport.Web.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TrainingsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingOutputModel>>> GetAll([FromQuery] GetAllTrainingsQuery command)
            => await this.Send(command);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateTrainingOutputModel>> Create(CreateTrainingCommand command)
            => await this.Send(command);

    }
}
