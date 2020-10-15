namespace RelaxAndSport.Application.Booking.Trainings
{
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITrainingsRepository : IRepository<Training>
    {
        Task<Training> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Trainer> GetTrainer(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TrainingOutputModel>> GetAll(CancellationToken cancellationToken = default);

        Task<TrainingOutputModel> GetById(int id, CancellationToken cancellationToken = default);
    }
}
