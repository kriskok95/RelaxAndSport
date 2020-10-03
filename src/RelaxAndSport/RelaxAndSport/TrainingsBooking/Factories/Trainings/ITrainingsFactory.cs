namespace RelaxAndSport.Domain.TrainingsBooking.Factories.Trainings
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.TrainingsBooking.Models.Trainings;
    using System;

    public interface ITrainingsFactory : IFactory<Training>
    {
        ITrainingsFactory WithType(string type);

        ITrainingsFactory WithTrainer(string firstName, string lastName);

        ITrainingsFactory WithTrainer(Trainer trainer);

        ITrainingsFactory WithDate(DateTime date);

        ITrainingsFactory WithSlots(int slots);

        ITrainingsFactory WithIsRepeated(bool isRepeated);

        ITrainingsFactory WithPrice(decimal price);
    }
}
