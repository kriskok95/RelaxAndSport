namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.MassagesAppointments;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Queries.Common;
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MassagesAppointmentsRepository : DataRepository<IBookingDbContext, MassageAppointment>, IMassagesAppointmentsRepository
    {
        private readonly IMapper mapper;

        public MassagesAppointmentsRepository(
            IBookingDbContext db, 
            IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<MassageAppointment> GetMassageAppointment(int id)
        {
            var massageAppointment = await this.Data
                .MassageAppointments
                .FirstOrDefaultAsync(ma => ma.Id == id);

            if (massageAppointment == null)
            {
                throw new InvalidMassageAppointmentException($"Massage appointment with Id {id} doesnt exists.");
            }

            return massageAppointment;
        }

        public async Task<bool> Delete(MassageAppointment massageAppointment, CancellationToken cancellationToken)
        {
            if (massageAppointment == null)
            {
                return false;
            }

            this.Data
                .MassageAppointments
                .Remove(massageAppointment);

            await this.Data
                .SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<MassageAppointmentOutputModel>> GetByDate(DateTime date)
        {
            var massageAppointments = await this.Data
                .MassageAppointments
                .Include(ma => ma.Massage)
                .Where(ma => ma.TimeRange.End.Date == date)
                .ToListAsync();

            return this.mapper
                .Map<IEnumerable<MassageAppointmentOutputModel>>(massageAppointments);
        }
    }
}
