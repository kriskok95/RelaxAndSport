namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using RelaxAndSport.Application.Booking.TrainingsAppointments;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Booking.Repositories;
    using RelaxAndSport.Infrastructure.Common.Persistence;

    internal class TrainingsAppointmentsRepository : DataRepository<IBookingDbContext, TrainingAppointment>,
        ITrainingsAppointmentsDomainRepository,
        ITrainingsAppointmentsQueryRepository
    {
        public TrainingsAppointmentsRepository(
            IBookingDbContext db) 
            : base(db)
        {
        }
    }
}
