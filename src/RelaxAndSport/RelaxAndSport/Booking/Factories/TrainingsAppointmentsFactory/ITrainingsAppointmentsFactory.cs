namespace RelaxAndSport.Domain.Booking.Factories.TrainingsAppointmentsFactory
{
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;
    using System;

    public interface ITrainingsAppointmentsFactory : IFactory<TrainingAppointment>
    {
        ITrainingsAppointmentsFactory WithTraining(Training training);

        ITrainingsAppointmentsFactory WithTimeRange(DateTime startDate, int duration);

        ITrainingsAppointmentsFactory WithTimeRange(DateTimeRange timeRange);
    }
}
