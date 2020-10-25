namespace RelaxAndSport.Application.Booking.Trainings
{
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITrainingsQueryRepository : IQueryRepository<Training>
    {
        Task<IEnumerable<TrainingOutputModel>> GetAll(CancellationToken cancellationToken = default);

        Task<TrainingOutputModel> GetTrainingOutputModelById(int id, CancellationToken cancellationToken = default);
    }
}
