namespace RelaxAndSport.Domain.Booking.Factories.Trainings
{
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Common;
    using System;

    public interface ITrainingsFactory : IFactory<Training>
    {
        ITrainingsFactory WithType(string category);

        ITrainingsFactory WithTrainer(string firstName, string lastName);

        ITrainingsFactory WithTrainer(Trainer trainer);

        ITrainingsFactory WithDate(DateTime date);

        ITrainingsFactory WithDuration(int duration);

        ITrainingsFactory WithSlots(int slots);

        ITrainingsFactory WithIsRepeated(bool isRepeated);

        ITrainingsFactory WithPrice(decimal price);
    }
}
