namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using RelaxAndSport.Application.Booking.MassagesAppointments;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Infrastructure.Common.Persistence;

    internal class MassagesAppointmentsRepository : DataRepository<IBookingDbContext, MassageAppointment>, IMassagesAppointmentsRepository
    {
        public MassagesAppointmentsRepository(IBookingDbContext db) 
            : base(db)
        {
        }
    }
}
